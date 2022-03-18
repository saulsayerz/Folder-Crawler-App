
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace FolderCrawler
{
    public partial class Form1 : Form
    {
        Boolean validFolder;
        Boolean selectedMethod;
        string startDir;
        folder startFolder;
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        Microsoft.Msagl.Drawing.Graph graph;
        public Form1()
        {
            validFolder = false;
            selectedMethod = false;
            startFolder = new folder();
            InitializeComponent();
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                label2.Text = fd.SelectedPath;
                validFolder = true;
                startDir = fd.SelectedPath;
            }
            else
            {
                label2.Text = "None Selected";
                validFolder = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            startFolder.clearEverything();
            if (validFolder)
            {
                label3.ForeColor = Color.Black;
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    startFolder.setCurDir(startDir);
                    startFolder.setEndFile(textBox1.Text);
                    if (BFS_optButton.Checked)
                    {
                        startFolder.BFS(toggleButton1.Checked);
                    }
                    else
                    {
                        startFolder.DFS(toggleButton1.Checked);
                    }
                    if (startFolder.found())
                    {
                        label3.Text = startFolder.getFoundDir()[0];
                    }
                    else
                    {
                        label3.Text = "File Not Found";
                    }
                    List<Edge> G = startFolder.getGraf();
                    List<List<string>> daftarFile = startFolder.getItemWaitingList();
                    List<List<string>> daftarFolder = startFolder.getFolderWaitingList();
                    if (startFolder.found())
                    {
                        label3.Text = startFolder.getFoundDir()[0];
                        viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                        graph = new Microsoft.Msagl.Drawing.Graph("graph");
                        graphPanel.Show();
                        bool found = false;
                        for (int i = 0; i <= G.Count; i++)
                        {
                            for(int j = 0; j < daftarFile[i].Count; j++)
                            {
                                string[] parts = daftarFile[i][j].Split(Path.DirectorySeparatorChar);
                                string parent = System.IO.Directory.GetParent(daftarFile[i][j]).FullName;
                                int index;
                                if(toggleButton1.Checked)
                                {
                                    index = startFolder.getFoundDir().Count;
                                }
                                else
                                {
                                    index = 1;
                                }
                                bool foundtemp = true;
                                bool foundtemp1 = false;
                                bool foundtemp2 = false;
                                bool foundtemp3 = false;
                                for(int k = 0; k < index; k++)
                                {   
                                    if (String.Equals(startFolder.getFoundDir()[k],daftarFile[i][j]))
                                    {       
                                            graph.AddEdge(parent, daftarFile[i][j]).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                            foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                                            {
                                                if(startFolder.getFoundDir()[k].Contains(edge.Target))
                                                {
                                                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                                }
                                            }
                                            found = true;
                                            foundtemp1 = true;
                                            break;
                                    } else { 
                                        continue;
                                    }
                                }
                                if(foundtemp1)
                                {

                                } else if (found && !toggleButton1.Checked)
                                {
                                    graph.AddEdge(parent, daftarFile[i][j]);
                                } else if (toggleButton1.Checked || !found)
                                {
                                    graph.AddEdge(parent, daftarFile[i][j]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                }
                                var ended = graph.FindNode(daftarFile[i][j]);
                                var started = graph.FindNode(parent);
                                ended.LabelText = parts[parts.Length - 1];
                                started.LabelText = parts[parts.Length - 2];
                                viewer.Graph = graph;
                                graphPanel.SuspendLayout();
                                viewer.Dock = DockStyle.Fill;
                                graphPanel.Controls.Add(viewer);
                                graphPanel.ResumeLayout();
                                sleep(500);
                            }
                            if(i != G.Count)
                            {
                                string[] parts_start = G[i].start.Split(Path.DirectorySeparatorChar);
                                string[] parts_end = G[i].end.Split(Path.DirectorySeparatorChar);
                                bool contain = false;
                                        foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                                        {
                                            if(String.Equals(edge.Target,G[i].end))
                                            {
                                                edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                        contain = true;

                                            } 
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                if(!contain)
                                {
                                    graph.AddEdge(G[i].start, G[i].end);
                                    var end = graph.FindNode(G[i].end);
                                    var start = graph.FindNode(G[i].start);
                                    end.LabelText = parts_end[parts_end.Length - 1];
                                    start.LabelText = parts_start[parts_start.Length - 1];

                                    viewer.Graph = graph;
                                    graphPanel.SuspendLayout();
                                    viewer.Dock = DockStyle.Fill;
                                    graphPanel.Controls.Add(viewer);
                                    graphPanel.ResumeLayout();
                                    sleep(500);
                                }
                            }
                            if(found == true || found == false)
                            {
                                for (int j = 0; j < daftarFolder[i].Count; j++)
                                    {
                                        bool contain = false;
                                        foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                                        {
              
                                            if(String.Equals(edge.Target,daftarFolder[i][j]))
                                            {
                                                edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                                contain = true;
                                                break;
                                            } 
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        if(!contain)
                                        {
                                                string[] parts = daftarFolder[i][j].Split(Path.DirectorySeparatorChar);
                                                string parent = System.IO.Directory.GetParent(daftarFolder[i][j]).FullName;
                                                if(toggleButton1.Checked)
                                                {
                                                    graph.AddEdge(parent, daftarFolder[i][j]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                                } else
                                                {
                                                    graph.AddEdge(parent, daftarFolder[i][j]);
                                                }
                                                var end = graph.FindNode(daftarFolder[i][j]);
                                                var start = graph.FindNode(parent);
                                                end.LabelText = parts[parts.Length - 1];
                                                start.LabelText = parts[parts.Length - 2];
                                        }
                                    }
                                viewer.Graph = graph;
                                graphPanel.SuspendLayout();
                                viewer.Dock = DockStyle.Fill;
                                graphPanel.Controls.Add(viewer);
                                graphPanel.ResumeLayout();
                                sleep(500);
                            }
                           
                        }
                        /* if(toggleButton1.Checked)
                        {
                            for(int i = 0; i < startFolder.getFoundDir().Count; i++)
                            {
                                foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                                {
                                    if(startFolder.getFoundDir()[i].Contains(edge.Target))
                                    {
                                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                    }
                                }
                            }
                        } else
                        {
                            foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                            {
                                if(startFolder.getFoundDir()[0].Contains(edge.Target))
                                {
                                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                                }
                            }
                        } */
                         viewer.Graph = graph;
                         graphPanel.SuspendLayout();
                         viewer.Dock = DockStyle.Fill;
                         graphPanel.Controls.Add(viewer);
                         graphPanel.ResumeLayout();
                         sleep(500);
                    }
                    else
                    {
                        label3.Text = "File Not Found";
                        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
                        graphPanel.SuspendLayout();
                        viewer.Dock = DockStyle.Fill;
                        graphPanel.Controls.Add(viewer);
                        graphPanel.ResumeLayout();
                        graphPanel.Show();
                        for (int j = 0; j < G.Count; j++)
                        {
                            string[] parts_start = G[j].start.Split(Path.DirectorySeparatorChar);
                            string[] parts_end = G[j].end.Split(Path.DirectorySeparatorChar);
                            graph.AddEdge(G[j].start, G[j].end).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            var end = graph.FindNode(G[j].end);
                            var start = graph.FindNode(G[j].start);
                            end.LabelText = parts_end[parts_end.Length - 1];
                            start.LabelText = parts_start[parts_start.Length - 1];
                            viewer.Graph = graph;
                            sleep(1000);
                        }
                        for (int i = 0; i < daftarFile.Count; i++)
                        {
                            for (int j = 0; j < daftarFile[i].Count; j++)
                            {
                                string[] parts = daftarFile[i][j].Split(Path.DirectorySeparatorChar);
                                string parent = System.IO.Directory.GetParent(daftarFile[i][j]).FullName;
                                if (parts.Length - 2 >= 0)
                                {
                                    graph.AddEdge(parent, daftarFile[i][j]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    var end = graph.FindNode(daftarFile[i][j]);
                                    var start = graph.FindNode(parent);
                                    end.LabelText = parts[parts.Length - 1];
                                    start.LabelText = parts[parts.Length - 2];
                                }
                            }
                        }
                        viewer.Graph = graph;
                        /* graphPanel.SuspendLayout();
                        viewer.Dock = DockStyle.Fill;
                        graphPanel.Controls.Add(viewer);
                        graphPanel.ResumeLayout();
                        graphPanel.Show(); */
                        sleep(500);
                    }
                }
            }
            else if (!validFolder)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Folder Invalid!";
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Search Mode Must be Selected!";
            }
            startFolder.clearEverything();
        }
        public void sleep(int ms)
        {
            var stopwatch = new System.Windows.Forms.Timer();
            if (ms > 0) {
                stopwatch.Interval = ms;
                stopwatch.Enabled = true;
                stopwatch.Start();

                stopwatch.Tick += (s, e) =>
                {
                    stopwatch.Enabled = false;
                    stopwatch.Stop();
                };

                while (stopwatch.Enabled)
                {
                    Application.DoEvents();
                }
            }


        }


        private void customButton1_Click(object sender, EventArgs e)
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph.AddEdge("test", "test1");
            graph.AddEdge("test", "test2");
            graph.AddEdge("test", "test1");
            graph.AddEdge("test1", "test3");
            viewer.Graph = graph;
            graphPanel.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(viewer);
            graphPanel.ResumeLayout();
            graphPanel.Show();
        }

    }
}