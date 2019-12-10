using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
//using SolidWorks.Interop.cosworks;
//using SolidWorks.Interop.sldworks;

namespace sw
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        // SW object
        SldWorks swApp;

        // Simulation variables
        CosmosWorks COSMOSWORKS = null;
        CwAddincallback CWAddinCallBack = default(CwAddincallback);
        CWModelDoc ActDoc = default(CWModelDoc);
        CWStudyManager StudyMngr = default(CWStudyManager);
        CWStudy Study = default(CWStudy);
        CWFrequencyStudyOptions CWOptions = default(CWFrequencyStudyOptions);
        CWLoadsAndRestraintsManager LBCMgr = default(CWLoadsAndRestraintsManager);
        CWRestraint CWBind = default(CWRestraint);
        CWMesh CWMesh = default(CWMesh);
        CWResults CWResult = default(CWResults);
        CWPlot plot = default(CWPlot);
        CWSolidManager SolidMgr = null;
        CWSolidComponent SolidComp = null;
        CWSolidBody SolidBody = null;

        ModelDoc2 Part = default(ModelDoc2);
        ModelDoc2 swDoc = null;
        int longstatus = 0;
        int longwarnings = 0;
        int errCode = 0;
        int solverIndex = 0;
        int freqNumber = 4;
        string studyName = "";
        string cwpath = "";

        // Guid SW 2017
        Guid Guid1 = new Guid("6B36082E-677B-49E8-BCB2-76698EBD2906");

        object[] results = null;

        // other thread work 
        BackgroundWorker bwStudy = new BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bwStudy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            bwStudy.WorkerSupportsCancellation = true;
            bwStudy.WorkerReportsProgress = true;
            bwStudy.ProgressChanged +=
                new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            solverComboBox.SelectedItem = solverComboBox.Items[0];
            freqComboBox.SelectedItem = freqComboBox.Items[3];
            startBtn.TabStop = false;
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            studyProcess.Value = e.ProgressPercentage;
        }

        private void solverComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            solverIndex = solverComboBox.SelectedIndex;
        }

        Dictionary<int, int> SolverDict = new Dictionary<int, int>()
        {
            {0, 1 },
            {1, 2 },
            {2, 0 },
            {3, 7 }
        };

        private void freqComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //freqNumber = freqComboBox.SelectedIndex + 1;
        }

        // dispose of actual SW processes
        private void DisposeSW()
        {
            Process[] processes = Process.GetProcessesByName("SLDWORKS");
            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.Kill();
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            studyName = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(studyName))
            {
                studyName = "Freq_Cantilever";
            }

            analysisLabel.Invoke((MethodInvoker)delegate
            {
                analysisLabel.Visible = true;
            });

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Disposing of SW processes...";
            });

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Visible = true;
            });

            // manual cancelling of the analysis
            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            DisposeSW();

            resGrid.Invoke((MethodInvoker)delegate
            {
                resGrid.Rows.Clear();
                resGrid.Refresh();
            });

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(5);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Launching SW...";
            });

            object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromCLSID(Guid1));
            swApp = (SldWorks)processSW;
            swApp.Visible = true;

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Loading Simulation library...";
            });

            // connecting Simulation to SW
            cwpath = swApp.GetExecutablePath() + @"\Simulation\cosworks.dll";
            errCode = swApp.LoadAddIn(cwpath);
            if (errCode != 0 && errCode != 2)
            {
                MessageBox.Show("Failed to load Simulation library");
                swApp.ExitApp();
                DisposeSW();
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Creating cantilever...";
            });

            // opening cantilever model
            Part = swApp.OpenDoc6("G:\\Cantilever.SLDPRT", 1, 0, "", ref longstatus, ref longwarnings);
            if (Part == null)
            {
                MessageBox.Show("Failed to load cantilever model");
                swApp.ExitApp();
                Dispose();
                Application.Exit();
            }

            swDoc = swApp.IActiveDoc2;
            swDoc.ShowNamedView2("*Isometric", 7);
            swDoc.ViewZoomtofit2();

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(10);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Check for Simulation readiness...";
            });

            // ready-check Simulation add-on
            CWAddinCallBack = (CwAddincallback)swApp.GetAddInObject("CosmosWorks.CosmosWorks");
            if (CWAddinCallBack == null)
            {
                MessageBox.Show("Failed to open Simulation");
                Application.Exit();
            }

            // ready-check add-on object
            COSMOSWORKS = CWAddinCallBack.CosmosWorks;
            if (COSMOSWORKS == null)
            {
                MessageBox.Show("Failed to create CosmosWorks object");
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(14);

            // connecting add-on to the document
            ActDoc = COSMOSWORKS.ActiveDoc;
            if (ActDoc == null)
            {
                MessageBox.Show("Failed to load document");
                Application.Exit();
            }

            bwStudy.ReportProgress(16);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Setting up an analysis...";
            });

            // creating a frequency analysis
            StudyMngr = ActDoc.StudyManager;
            if (StudyMngr == null)
            {
                MessageBox.Show("Failed to load analysis manager");
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(18);

            // analysis creation
            Study = StudyMngr.CreateNewStudy3(studyName,
                (int)swsAnalysisStudyType_e.swsAnalysisStudyTypeFrequency,
                (int)swsMeshType_e.swsMeshTypeSolid, out errCode);
            if (Study == null)
            {
                MessageBox.Show("Failed to create a frequency analysis");
                Application.Exit();
            }

            // analysis settings
            CWOptions = Study.FrequencyStudyOptions;
            // finite element method solver
            // 1 - Automatic Solver Selection, 0 - Direct sparse solver, 2 - FFEPlus, 7 - Intel Direct Sparse
            Study.FrequencyStudyOptions.SolverType = SolverDict[solverIndex];
            Study.FrequencyStudyOptions.NoOfFrequencies = freqNumber;
            if (CWOptions == null)
                MessageBox.Show("No analysis settings");

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(20);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Setting cantilever material...";
            });

            // using silicon as the material (don't know why)
            string matLib = swApp.GetExecutablePath() +
                @"\lang\english\sldmaterials\solidworks materials.sldmat";
            SolidMgr = (CWSolidManager)Study.SolidManager;
            SolidComp = SolidMgr.GetComponentAt(0, out errCode);
            if (errCode == 0)
            {
                SolidBody = (CWSolidBody)SolidComp.GetSolidBodyAt(0, out errCode);
                errCode = (int)SolidBody.SetLibraryMaterial(matLib, "Silicon");
            }
            else
            {
                MessageBox.Show("Failed to apply material");
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Adding restraints...";
            });

            // loading loads and restraints manager
            LBCMgr = Study.LoadsAndRestraintsManager;
            if (LBCMgr == null)
            {
                MessageBox.Show("Failed to load loads and restraints manager");
                Application.Exit();
            }

            bwStudy.ReportProgress(25);

            // face selection followed by applying restraints
            ISelectionMgr selectionMgr = (ISelectionMgr)swDoc.SelectionManager;
            bool isSelected = swDoc.Extension.SelectByRay(0.018229940747914952, 0.051969523507693793,
                0.0020000000000095497, -0.57738154519998097, -0.5772877120855483, -0.57738154519997897,
                0.00085899699451767535, 2, false, 0, 0);
            if (isSelected)
            {
                object face_bind = selectionMgr.GetSelectedObject6(1, -1);
                object[] fixedpart = { face_bind };
                CWBind = (CWRestraint)LBCMgr.AddRestraint(0, (fixedpart), null, out errCode);
                if (errCode != 0)
                {
                    MessageBox.Show("Failed to add restraints");
                    Application.Exit();
                }
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(35);

            swDoc.ClearSelection2(true);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Creating mesh object...";
            });

            swDoc.ClearSelection2(true);

            // mesh object options
            CWMesh = ((CWMesh)(Study.Mesh));
            CWMesh.Quality = 1;
            CWMesh.UseJacobianCheckForSolids = 1;
            CWMesh.MesherType = 0;
            CWMesh.AutomaticTransition = 0;
            CWMesh.AutomaticLooping = 0;
            CWMesh.NumberOfLoops = 3;
            CWMesh.SaveSettingsWithoutMeshing = 0;
            CWMesh.Unit = 0;

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(50);

            // create mesh object
            errCode = Study.CreateMesh(0, 13.3821, 0.669103);
            if (errCode != 0)
            {
                MessageBox.Show("Failed to create mesh object");
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Analysing...";
            });

            // start of analysis
            errCode = Study.RunAnalysis();
            if (errCode != 0)
            {
                MessageBox.Show("Failed to start analysis");
                Application.Exit();
            }

            if (bwStudy.CancellationPending == true)
            {
                processNameLabel.Invoke((MethodInvoker)delegate
                {
                    processNameLabel.Text = "Analysis has been stopped by user";
                    startBtn.Text = "Start analysis";
                    solverComboBox.Enabled = true;
                    freqComboBox.Enabled = true;
                });

                e.Cancel = true;
                return;
            }

            bwStudy.ReportProgress(90);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Receiving results of analysis...";
            });

            // getting results
            CWResult = (CWResults)Study.Results;
            if (CWResult == null)
            {
                MessageBox.Show("Failed to receive results of analysis");
                return;
            }

            double[] res = new double[10];

            // getting results from the graph
            for (int i = 0; i < freqNumber; i++)
            {
                plot = CWResult.GetPlot("Amplitude" + (i + 1).ToString(), out errCode);
                if (plot == null)
                {
                    MessageBox.Show("Failed to load an information from the graph");
                    return;
                }
                plot.SetComponentUnitAndValueByElem(9, 3, false);
                results = (object[])plot.GetMinMaxResultValues(out errCode);
                res[i] = Convert.ToDouble(results[3].ToString());
            }

            for (int k = 0; k < freqNumber; k++)
            {
                resGrid.Invoke((MethodInvoker)delegate
                {
                    int n = resGrid.Rows.Add();
                    resGrid.Rows[n].Cells[0].Value = k + 1;
                    resGrid.Rows[n].Cells[1].Value = res[k];
                });
            }

            bwStudy.ReportProgress(100);

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                processNameLabel.Text = "Done";
            });

            processNameLabel.Invoke((MethodInvoker)delegate
            {
                startBtn.Text = "Review results";
                solverComboBox.Enabled = true;
                freqComboBox.Enabled = true;
            });

        }

        // 3-state button
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start analysis")
            {
                this.Size = new Size(542, 322);
                startBtn.Text = "Cancel analysis";
                solverComboBox.Enabled = false;
                freqComboBox.Enabled = false;
                if (!bwStudy.IsBusy)
                {
                    bwStudy.RunWorkerAsync();
                }
            }
            else if (startBtn.Text == "Cancel analysis")
            {
                bwStudy.CancelAsync();
                if (processNameLabel.Text == "Analysis has been cancelled")
                    startBtn.Text = "Start analysis";

            }
            else if (startBtn.Text == "Review results")
            {
                startBtn.Text = "Start analysis";
                this.Size = new Size(542, 568);
            }
        }
    }
}