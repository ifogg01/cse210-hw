using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    class Comment
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public void DisplayComment()
        {
            Console.WriteLine($"{Name}: {Text}");
        }
    }

    class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in Comments)
            {
                comment.DisplayComment();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
    
        {
            Console.WriteLine("");
            List<Video> videoList = new List<Video>();

            Video video1 = new Video("RetroPie: A Raspberry Pi Gaming Machine", "NetworkChuck", 1982);
            video1.AddComment(new Comment("JohanlastZa", @"Imagine taking this little piece of hardware back in time and showing all those 
             console gamers what they will be able to do in the future on ONE device"));
            video1.AddComment(new Comment("Rand00mThing", @"I really liked this video. Thank you so much for not only teaching us how to create this 
             makeshift retro gaming console but also for showing us how to preserve old classics"));
            video1.AddComment(new Comment("StreamingInSeattle", "I just built 2 of these last week -- The bonus configuration options were super helpful!"));
            videoList.Add(video1);


           Video video2 = new Video("Don't Hug Me I'm Scared", "donthugmeimscared", 204);
           video2.AddComment(new Comment("ImmortalSugimoto792", "I just realized something: she says being creative is her favorite IDEA. She likes the idea of creativity, but not actual creativity."));
           video2.AddComment(new Comment("mayab8053", "It honestly infuriates me just how catchy this tune is."));
           video2.AddComment(new Comment("Jack-sk3we", "the comment section is still thriving after 10 years. that’s dedication"));
           videoList.Add(video2);


            Video video3 = new Video("The Past We Can Never Return To – The Anthropocene Reviewed", "Kurzgesagt – In a Nutshell", 509);
            video3.AddComment(new Comment("ananyabhalla2520", @"This a handprint, but not a hand. This is  a memory you can't return to. This made me cry somehow."));
            video3.AddComment(new Comment("puiu102006", "Wow at the end when John stopped talking i just remembered this was a Kurzgesagt video. He did a super good job"));
            video3.AddComment(new Comment("purplehaze2358", "This honestly gave me a sort of...existential melancholic longing."));
            videoList.Add(video3);


            Video video4 = new Video("Metallica: Enter Sandman", "Metallica", 330);
            video4.AddComment(new Comment("barcaforlife5648", "Even if you don't like metal, you have to admit that this is art at its best"));
            video4.AddComment(new Comment("mge8036", "almost 35 years later and this is still boss in heavy metal... One of the best songs ever played in heavy metal."));
            video4.AddComment(new Comment("phadearts4811", "i've just learnt it on guitar, nobody ever cared but im kinda proud."));
            videoList.Add(video4);


            foreach (Video video in videoList)
            {
                video.DisplayVideoInfo();
                Console.WriteLine(); 
            }

            Console.ReadLine();
        }
    }
}
