
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

        public void refresh_graph(Microsoft.Msagl.Drawing.Graph graph, Microsoft.Msagl.GraphViewerGdi.GViewer viewer)
        {
            viewer.Graph = graph;
            graphPanel.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(viewer);
            graphPanel.ResumeLayout();
            sleep(500);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            startFolder.clearEverything();
            graphPanel.Controls.Clear();
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
                        foreach (var link in startFolder.getFoundDir())
                        {
                            LinkLabel newLink = new LinkLabel();
                            newLink.Text = link;
                            newLink.AutoSize = true;
                            newLink.Click += new EventHandler(linkClick);
                            flowLayoutPanel1.Controls.Add(newLink);

                        }                  
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
                                refresh_graph(graph,viewer);
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
                                    refresh_graph(graph,viewer);
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
                                        } 
                                        else
                                        {
                                            graph.AddEdge(parent, daftarFolder[i][j]);
                                        }
                                        var end = graph.FindNode(daftarFolder[i][j]);
                                        var start = graph.FindNode(parent);
                                        end.LabelText = parts[parts.Length - 1];
                                        start.LabelText = parts[parts.Length - 2];
                                    }
                                    refresh_graph(graph,viewer);
                                }
                                refresh_graph(graph,viewer);
                            }
                           
                        }
                         refresh_graph(graph,viewer);
                    }
                    else
                    {
                        label3.Text = "File Not Found";
                        viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                        graph = new Microsoft.Msagl.Drawing.Graph("graph");
                        graphPanel.Show();
                        for (int i = 0; i <= G.Count; i++)
                        {
                            for(int j = 0; j < daftarFile[i].Count; j++)
                            {
                                string[] parts = daftarFile[i][j].Split(Path.DirectorySeparatorChar);
                                string parent = System.IO.Directory.GetParent(daftarFile[i][j]).FullName;
                                graph.AddEdge(parent, daftarFile[i][j]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                var ended = graph.FindNode(daftarFile[i][j]);
                                var started = graph.FindNode(parent);
                                ended.LabelText = parts[parts.Length - 1];
                                started.LabelText = parts[parts.Length - 2];
                                refresh_graph(graph,viewer);
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
                            refresh_graph(graph,viewer);
                            }
                         refresh_graph(graph,viewer);
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

        void linkClick(Object sender, EventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(link.Text));
        }

    }
}