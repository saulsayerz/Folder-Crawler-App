using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FolderCrawler
{

    /// <summary>
    /// This edge class is what we use to save the edges for the graph visualization.
    /// The attributes are Start and End which are the full paths for the nodes.
    /// The print function only prints the filename of the nodes, not the full path.
    /// </summary>
    class Edge {
        public string start;
        public string end;
        public void print()
        {
            Console.WriteLine(
                Path.GetFileName(start) +
                " -> " +
                Path.GetFileName(end)
            );
        }
    }

 /// <summary>
    /// This folder class is what we use to save the CURRENT folder we're traversing.
    /// BFS and DFS algorithm are inside this class
    /// The attributes are :
    /// 1. curDir : a string to determine the current directory we are traversing
    /// 2. endFIle : a string, the name of the file we are trying to search for
    /// 3. found : a boolean, true if the file is found so traverse is stopped
    /// 4. foundDir : a string, the full path of the file we're searching for
    /// 5. graf : a list of edges
    /// </summary>
    class folder
    {

        // Attributes: 
        private string curDir = default!; //tbh gatau knp harus = default!, tapi di komputerku kalau gk ada itu error
        private string endFile = default! ;
        private string foundDir = default!;
        private Boolean found = false; //kondisi awal --> file belum ditemukan
        public List<Edge> Graf = new List<Edge>() ; // List of edges, misalnya [[A,B],[B,C]]

        // Getter 
        public string getCurDir()
        {
            return curDir;
        }

        public string getEndFile()
        {
            return endFile;
        }

        public bool getFound()
        {
            return found;
        }

        public string getFoundDir()
        {
            return foundDir;
        }
        

        // Setter 
        public void setCurDir(string newCurDir)
        {
            this.curDir = newCurDir; 
        }

        public void setEndFile(string newEndFile)
        {
            this.endFile = newEndFile; 
        }
        
        public void setFound(bool newFound)
        {
            this.found = newFound; 
        }

        public void setFoundDir(string newFoundDir)
        {
            this.foundDir = newFoundDir;
        }


        // To get input for the attributes
        public void inputSearch() 
        {
           Console.WriteLine("Enter directory root:");
            this.curDir = Console.ReadLine();
            while (!System.IO.Directory.Exists(this.getCurDir())) {
                Console.WriteLine("Directory not found! enter new directory: ");
                setCurDir(Console.ReadLine());
            }

            Console.WriteLine("Enter filename to search:");
            setEndFile(Console.ReadLine());
        }

        //To chose DFS or BFS algorithm
        public int chooseAlgorithm()
        {
            Console.WriteLine("\nChoose the algorithm to find the file. ");
            Console.WriteLine("1. For DFS (default)");
            Console.WriteLine("2. For BFS ");
            Console.Write("Enter your choice: ");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            return choice;
        }

        public void checkFiles(){
            string[] listOfFiles = Directory.GetFiles(this.getCurDir());
            string namafile = null;
            foreach (var item in listOfFiles) 
            {
                namafile = Path.GetFileName(item);
                if (namafile == this.getEndFile()) 
                {
                    this.found = true;
                    setFoundDir(item);
                    Console.WriteLine(getFoundDir());
                    break;
                }
            }
        }

        public void addToGraf()
        {
            Graf.Add( new Edge {
                start = Path.GetDirectoryName(this.curDir),
                end = this.curDir
            }) ;
        }

        //Search for the file using the DFS algorithm.
        public bool DFS(){

            // Check the current path first. Does it have the file we are searching for?
            this.checkFiles();

            // If file is not present in the current path, we continue to traverse for each subdirectory.
            if (!this.found)
            {
                string[] listOfSubDir = Directory.GetDirectories(this.getCurDir());
                string tempStartDir = this.getCurDir();
                foreach (var item in listOfSubDir) 
                {
                    if (this.found) 
                    {
                        break;
                    }
                    this.setCurDir(item);
                    addToGraf();
                    this.found = this.DFS();
                }
                this.setCurDir(tempStartDir); // to reset the startDir the way it was
            }
            return this.found;
        }
        public bool BFS(){
            //Check the start directory, does it have the file we're searching for?
            this.checkFiles();
            
            //In case the file is not found, iterate for every subdirectory using BFS traverse
            string[] listOfSubDir = Directory.GetDirectories(this.getCurDir());
            string tempStartDir = this.getCurDir();

            while (!this.found && listOfSubDir.Any())
            {
                this.setCurDir(listOfSubDir[0]);
                addToGraf();
                this.checkFiles();
                listOfSubDir = listOfSubDir.Concat(Directory.GetDirectories(this.getCurDir())).ToArray();
                listOfSubDir = listOfSubDir.Where(path => path != listOfSubDir[0]).ToArray(); // Remove the first path on the list

            }

            this.setCurDir(tempStartDir); // to reset the startDir the way it was
           
            return this.found;
        }
    }

    class main {
        
        /// <summary>
        /// Main class to run, implement, test, and debug the search algorithm
        /// </summary>
        static void Main(string[] args) {
            bool found = false;
            folder start = new folder();
            start.inputSearch();

            int choice = start.chooseAlgorithm();
            if (choice == 2)
            {
                found = start.BFS();
            }
            else 
            {
                found = start.DFS();
            }

            Console.WriteLine("\nList of edges: ");
            foreach (var item in start.Graf)
            {
                item.print();
            }

            /*Console.WriteLine("");
            Console.WriteLine(Path.GetDirectoryName("test"));
            Console.WriteLine(Path.GetFileName("test"));*/
        }
    }
}