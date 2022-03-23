# Tubes 2 DoiFinders 
> Folder Crawler program for file search using DFS and BFS algorithm written in C#

Repository program Folder Crawler ini dibuat untuk memenuhi **Tugas Besar Mata Kuliah IF2211 Strategi Algoritma** yang ke-2 pada Semester II Tahun Akademik 2021/2022.

## Table of Contents
- [Tubes 2 DoiFinders](#tubes-2-doifinders)
  - [Table of Contents](#table-of-contents)
  - [Program Description](#program-description)
  - [DFS and BFS algorithm](#dfs-and-bfs-algorithm)
  - [Requirement and Installation](#requirement-and-installation)
  - [Compile Program](#compile-program)
  - [How To Use Program](#how-to-use-program)
  - [Author](#author)

## Program Description
Program kami merupakan program berbasis GUI yang ditulis dalam bahasa C# untuk mengimplementasikan *Folder Crawling*, yakni proses pencarian path suatu file dengan memasukkan sebuah query nama file yang ingin kita cari dan direktori folder awal yang ingin kita cari, kemudian akan ditampilkan path dari file yang ingin kita cari. Program akan mulai mencari file yang sesuai dengan query mulai dari starting directory hingga seluruh children dari starting directory tersebut sampai satu file pertama/seluruh file ditemukan (user dapat memilih) atau tidak ada file yang ditemukan. Progress pencarian file tersebut akan ditampilkan dalam bentuk pohon per-langkahnya. Dalam visualisasi grafnya, simpul dan sisi akan ditandai dengan 3 warna yang masing - masingnya memiliki warna :
- Hitam : Simpul tersebut sudah ditemukan dan masuk waiting list untuk pengecekan, namun belum diperiksa.
- Merah : Simpul tersebut sudah diperiksa, namun bukan merupakan solusi dari query file yang kita cari.
- Biru : Simpul tersebut sudah diperiksa dan merupakan solusi query file yang kita cari.

Selain itu, program kami juga akan menampilkan list path dari daun-daun yang bersesuaian (solusi dari query file) dengan hasil pencarian. Path tersebut memiliki hyperlink menuju folder parent darifile yang dicari sehingga file langsung dapat diakses file explorer. Metode *Folder Crawling* kami diimplementasikan menggunakan pendekatan algoritma Breadth First Search (BFS) dan Depth First Search (DFS). Anda bisa mengakses video demonstrasi dari program ini melalui link <a href="https://www.youtube.com/watch?v=szw9YO8qABA">berikut.</a>

## DFS and BFS Algorithm 
- Breadth First Search (BFS) : Algoritma pencarian grafnya dimulai dari direktori folder awal yang dipilih yang kemudian menelusuri semua simpul tetangganya (subdirektori dan file di dalamnya). Kemudian, untuk setiap simpul yang terdekat itu, ditelusuri simpul tetangga yang belum diperiksa, dan demikian seterusnya, sampai ditemukan simpul tujuan. BFS adalah metode pencarian yang bertujuan memperluas dan memeriksa semua simpul pada graf.  Dengan kata lain, BFS secara penuh mencoba mencari pada keseluruhan graf dengan urutan langkah yang tidak memikirkan tujuan sampai akhirnya menemukan tujuan itu sendiri. 

- Depth First Search (DFS) : pencarian yang berjalan dengan meluaskan subdirektori pertama dari direktori folder awal yang dipilih dan berjalan dalam dan lebih dalam lagi sampai simpul tujuan (file yang dicari) ditemukan, atau sampai menemukan simpul yang tidak punya anak (subdirektori yang tidak memiliki subdirektori lagi di dalamnya). Kemudian, pencarian backtracking, akan kembali ke simpul yang belum selesai ditelusuri.

## Requirement and Installation
Requirement : 
- Visual Studio. You can download it <a href="https://code.visualstudio.com/download">here.</a>
- .NET Framework. You can download it <a href="https://dotnet.microsoft.com/en-us/download/dotnet-framework">here.</a>
- Install nugget packages such as MSAGL library. You can install them in the extension section of Visual Studio.

## Compile Program
- Open project solution in ../src/FolderCrawler. Project will be opened in Visual Studio.
- Right Click Solution 'FolderCrawler' in solution Explorer.
- Build Solution (Alternative : Ctrl + Shift + B)
- Create executable file by Start Without Debugging (Ctrl + F5)

## How To Use Program
- Open project executable file in ../src/FolderCrawler/bin/Debug/net4.8.
- Open starting folder by clicking Choose Start Folder and set destination file in File To Find: Textbox (by default: example.jpg)
- Configure search settings (BFS/DFS mode, graph search interval, and Search All Occurence option).
- Click Find File, resulting figure and hyperlink texts will be shown in panel below.

## Author
>Project ini dibuat oleh kelompok 43 yang beranggotakan :
>- <a href="https://www.linkedin.com/in/ng-kyle-b649a51ba/">Ng Kyle (13520040)</a>
>- <a href="https://www.linkedin.com/in/marcellus-michael-herman-kahari/">Marcellus Michael Herman Kahari (13520057)</a>
>- <a href="https://www.linkedin.com/in/saulsayers/?originalSubdomain=id">Saul Sayers (13520094)</a>

