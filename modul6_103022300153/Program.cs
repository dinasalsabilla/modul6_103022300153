namespace modul6_103022300153
{
    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title == null || title.Length > 200)
                throw new ArgumentException("Judul video tidak boleh null dan maksimal 200 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int countIncreasePlay)
        {
            if (countIncreasePlay > 25000000)
                throw new ArgumentException("Penambahan play count maksimal 25.000.000 per panggilan.");

            try
            {
                checked
                {
                    this.playCount += countIncreasePlay;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Play count melebihi batas maksimum.");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("Video ID: " + this.id);
            Console.WriteLine("Title: " + this.title);
            Console.WriteLine("Play Count: " + this.playCount);
        }

        internal int GetVideoPlayCount()
        {
            throw new NotImplementedException();
        }
    }

    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string username;
        private int countIncreasePlay;

        public SayaTubeUser(string username)
        {
            if (username == null || username.Length > 100)
                throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.uploadedVideos = uploadedVideos;
            this.username = username;
        }

        public int GetVideoPlayCount()
        {
            return this.countIncreasePlay;
        }
        public void GetTotalVideoPlayCount()
        {
            int count = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                count += uploadedVideos[i].GetVideoPlayCount();
            }
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null)
                throw new ArgumentException("Video tidak boleh null.");

            try
            {
                checked
                {
                    this.uploadedVideos.Add(video);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Video yang ditambahkan punya play count melebihi batas maksimum.");
            }
        }

        public void PrintAllVideoPlayCount()
        {
            Console.WriteLine("User: " + this.username);
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine("Video " + (i+1) + " judul: " + this.uploadedVideos);
            }
        }

    }

    class Program
    {
        static void Main()
        {
            try
            {
                SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - [Dina Salsabillla]");
                for (int i = 0; i < 100; i++)
                {
                    video.IncreasePlayCount(25000000);
                }
                video.PrintVideoDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
        }
    }
}