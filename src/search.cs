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
    /// 2. endFile : a string, the name of the file we are trying to search for
    /// 3. foundDir : a list of string, array of the path to the solution
    /// 4. graf : a list of edges, for example [A/B/C, A/B/C/D]. Sorted by time checked (1 for each step)
    /// 5. itemWaitingList : an array of array of nodes which are items, the index means which step they enter the waiting list
    /// 6. folderWaitingList : an array of array of nodes which are folders, the index means which step they enter the waiting list
    /// 7. emptyFolders: an array of folders which are empty
    /// </summary>
    class folder
    {

        // Attributes: 
        public string curDir; 
        public string endFile;
        public List<string> foundDir = new List<string>();
        
        public List<Edge> Graf = new List<Edge>() ; // List of edges, misalnya [[A,B],[B,C]]
        public List<List<string>> itemWaitingList = new List<List<string>>(); // 
        public List<List<string>> folderWaitingList = new List<List<string>>();
        public List<string> emptyFolders = new List<string>();

        // Getter 
        public string getCurDir()
        {
            return curDir;
        }

        public string getEndFile()
        {
            return endFile;
        }

        public bool found()
        {
            return foundDir.Count > 0;
        }

        public List<string> getFoundDir()
        {
            return foundDir;
        }
        
        public List<Edge> getGraf()
        {
            return Graf;
        }

        public List<List<string>> getItemWaitingList()
        {
            return itemWaitingList;
        }

        public List<List<string>> getFolderWaitingList()
        {
            return folderWaitingList;
        }
        public List<string> getEmptyFolders()
        {
            return emptyFolders;
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
            this.itemWaitingList.Add(listOfFiles.ToList());

            foreach (var item in listOfFiles) 
            {
                namafile = Path.GetFileName(item);
                if (namafile == this.getEndFile()) 
                {
                    this.foundDir.Add(item);
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

        public void addToEmptyFolders()
        {
            if (!Directory.GetDirectories(this.getCurDir()).Any() && !Directory.GetFiles(this.getCurDir()).Any())
            {
                emptyFolders.Add(this.getCurDir());
            }
        }

        // Must be used everytime we try to search again to reset everything
        public void clearEverything() {
            itemWaitingList.Clear() ;
            folderWaitingList.Clear() ;
            foundDir.Clear() ;
            Graf.Clear() ;
            emptyFolders.Clear() ;
        }

        //Search for the file using the DFS algorithm.
        public void DFS(bool allOccurence){

            // Check the current path first. Does it have the file we are searching for?
            this.checkFiles();
            addToEmptyFolders();

            //In case the file is not found, iterate for every subdirectory using DFS traverse
            string[] listOfSubDir = Directory.GetDirectories(this.getCurDir());
            this.folderWaitingList.Add(listOfSubDir.ToList());
            string tempStartDir = this.getCurDir();

            foreach (var item in listOfSubDir) 
            {
                if (this.found() && !allOccurence) 
                {
                    break;
                }
                this.setCurDir(item);
                addToGraf();
                this.DFS(allOccurence);
            }
            this.setCurDir(tempStartDir); // to reset the startDir the way it was
        }
        public void BFS(bool allOccurence){

            //Check the start directory, does it have the file we're searching for?
            this.checkFiles();
            addToEmptyFolders();
            
            //In case the file is not found, iterate for every subdirectory using BFS traverse
            string[] listOfSubDir = Directory.GetDirectories(this.getCurDir());
            this.folderWaitingList.Add(listOfSubDir.ToList());
            string tempStartDir = this.getCurDir();

            while (((!allOccurence && !this.found()) || allOccurence) && listOfSubDir.Any())
            {
                this.setCurDir(listOfSubDir[0]);
                addToGraf();
                this.checkFiles();
                addToEmptyFolders();
                this.folderWaitingList.Add(Directory.GetDirectories(this.getCurDir()).ToList());
                listOfSubDir = listOfSubDir.Concat(Directory.GetDirectories(this.getCurDir())).ToArray();
                listOfSubDir = listOfSubDir.Where(path => path != listOfSubDir[0]).ToArray(); // Remove the first path on the list
            }

            this.setCurDir(tempStartDir); // to reset the startDir the way it was
        }
    }

    class main {
        
        /// <summary>
        /// Main class to run, implement, test, and debug the search algorithm
        /// </summary>
        static void Main(string[] args) {
            folder start = new folder();
            start.inputSearch();

            int choice = start.chooseAlgorithm();
            if (choice == 2)
            {
                start.BFS(false);
            }
            else 
            {
                start.DFS(false);
            }

            Console.WriteLine("\nUrutan traverse: ");
            foreach (var item in start.Graf)
            {
                item.print();
            }

            Console.WriteLine("");
            Console.WriteLine("ITEM WAITING LIST:");
            int count = 0;
            foreach (var anotherlist in start.itemWaitingList){
                count += 1;
                Console.WriteLine("Step ke-" + count.ToString() + ": ");
                foreach(var item in anotherlist) {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("FOLDER WAITING LIST:");
            count = 0;
            foreach (var anotherlist in start.folderWaitingList){
                count += 1;
                Console.WriteLine("Step ke-" + count.ToString() + ": ");
                foreach(var item in anotherlist) {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("EMPTY FOLDERS LIST:");
            count = 0;
            foreach (var path in start.emptyFolders){
                count += 1;
                Console.WriteLine("Folder ke-" + count.ToString() + ": ");
                Console.WriteLine(path);
            }
        }
    }
}