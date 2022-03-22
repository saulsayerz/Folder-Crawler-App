
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace FolderCrawler
{
    public partial class Form1 : Form
    {
        Boolean validFolder;
        string startDir;
        folder startFolder;
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        Microsoft.Msagl.Drawing.Graph graph;
        public Form1()
        {
            validFolder = false;
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
            sleep(trackBar1.Value);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            startFolder.clearEverything();
            graphPanel.Controls.Clear();
            flowLayoutPanel1.Controls.Clear();
            if (validFolder)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    startFolder.setCurDir(startDir);
                    startFolder.setEndFile(textBox1.Text);
                    if (BFS_optButton.Checked)
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        startFolder.BFS(toggleButton1.Checked);
                        sw.Stop();
                        label11.Text = "Algorithm Time: " + sw.ElapsedMilliseconds.ToString() + " ms";
                    }
                    else
                    {
                        Stopwatch sw = Stopwatch.StartNew();
                        startFolder.DFS(toggleButton1.Checked);
                        sw.Stop();
                        label11.Text = "Algorithm Time: " + sw.ElapsedMilliseconds.ToString() + " ms";
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
                    }
                    else
                    {
                        label3.ForeColor = Color.Black;
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
                                                    graph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                                                    graph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
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
                            for (int j = 0; j < daftarFolder[i].Count; j++)
                            {
                                bool contain = false;
                                foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                                {
              
                                    if(String.Equals(edge.Target,daftarFolder[i][j]))
                                    {
                                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                        if(j == daftarFolder[i].Count - 1)
                                        {   bool founded = false;
                                            if(toggleButton1.Checked)
                                            {
                                                for(int k = 0; k < startFolder.getFoundDir().Count; k++)
                                                {
                                                    if(startFolder.getFoundDir()[k].Contains(edge.Source)) {
                                                        founded = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        contain = true;
                                        break;
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
                        }
                        foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                        {
                            bool founded = false;
                            bool founded1 = false;
                            bool founded2 = false;
                            for(int j = 0; j < startFolder.getFoundDir().Count; j++)
                            {
                                if(startFolder.getFoundDir()[j].Contains(edge.Target))
                                {
                                    founded = true;
                                }
                                if(startFolder.getFoundDir()[j].Contains(edge.Source))
                                {
                                    founded1 = true;
                                }
                                if(String.Equals(startFolder.getFoundDir()[j],edge.Target))
                                {
                                    founded2 = true;
                                }
                                if(founded && founded1 && founded2)
                                {
                                    break;
                                }
                            }
                            if(true)
                            {
                                List<string> emptyFolder = startFolder.getEmptyFolders();
                                if(!founded1 && !founded)
                                {
                                    graph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                }
                                for(int j = 0; j < G.Count; j++) 
                                { 
                                    if(String.Equals(G[j].start,edge.Source) && !founded1)
                                    {
                                        graph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                    }
                                    for(int k = 0; k < emptyFolder.Count; k++)
                                    {
                                        if(String.Equals(edge.Target,emptyFolder[k]))
                                        {
                                            graph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                        }
                                    }
                                }
                                for(int j = 0; j < daftarFile.Count; j++)
                                {
                                    for(int k = 0; k < daftarFile[j].Count; k++)
                                    {
                                        if((String.Equals(daftarFile[j][k],edge.Target) || toggleButton1.Checked) && !founded2)
                                        {
                                            graph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                        }
                                    }
                                }
                            }
                        }
                         refresh_graph(graph,viewer);
                    }
                    else
                    {
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
                                        refresh_graph(graph,viewer);
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
                        foreach(Microsoft.Msagl.Drawing.Edge edge in graph.Edges)
                        {
                            graph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                            graph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        }
                         refresh_graph(graph,viewer);
                         label3.Text = "File Not Found";
                    }
                }
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Folder Invalid!";
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label10.Text = trackBar1.Value.ToString() + " ms";
        }
    }
}