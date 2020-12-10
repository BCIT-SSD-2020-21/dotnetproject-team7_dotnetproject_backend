using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTeam7API.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTeam7API.Data
{
    public class MovieDbSeeder
    {
        // tQ: return type for async is Task
        public static async Task SeedAsync(MovieDbContext db)
        {
            if (!await db.Genres.AnyAsync())
            {
                // tQ: add range of movie genres
                await db.Genres.AddRangeAsync(GetPreconfiguredGenres());
                //await db.SaveChangesAsync();
            }
            //if (!await db.Movies.AnyAsync())
            {
                // tQ: add range of movies
                await db.Movies.AddRangeAsync(GetPreconfiguredItems());
                //await db.SaveChangesAsync();
            }
            if (!await db.MovieGenres.AnyAsync())
            {
                // tQ: add range of movie genres
                await db.MovieGenres.AddRangeAsync(GetPreconfiguredMovieGenres());
                //await db.SaveChangesAsync();
            }
        }

        static IEnumerable<Movie> GetPreconfiguredItems()
        {
            return (IEnumerable<Movie>)MovieDbSeedConverter.Convert();

        //    return new List<Movie>()
        //    {
        //        new Movie("/mXouvrZbn8YpZMURGvw30QK8qfo.jpg", "2019-08-22", 89641, "Love Alarm", "ko", "좋아하면 울리는", "Love Alarm is an app that tells you if someone within a 10-meter radius has a crush on you. It quickly becomes a social phenomenon. While everyone talks about it and uses it to test their love and popularity, Jojo is one of the few people who have yet to download the app. However, she soon faces a love triangle situation between Sun-oh whom she starts to have feelings for, and Hye-young, who has had a huge crush on her.", 166.605, "/s87JyAWtRLLlmsYWXTED1l8henB.jpg", 8.4, 577),
        //        new Movie("/g1xn0ce0PQ5Kk7FSj6lMuLNqyiX.jpg", "2009-01-05", 16420, "Boys Over Flowers", "ko", "꽃보다 남자", "A working class girl winds up at an exclusive prep school. Unassuming high school girl Jan Di stands up to -- and eventually falls for -- a spoiled rich kid who belongs to the school's most powerful clique.", 84.115, "/Apn2ccFuy7uahKAd0Kb9DbQQvNY.jpg", 8.3, 876),
        //        new Movie("/rHuXgDmrv4vMKgQZ6pu2E2iLJnM.jpg", "2010-07-11", 33238, "Running Man", "ko", "런닝맨", "A landmark representing Korea, how much do you know? Korea's representative landmark to let the running man know directly! The best performers of Korea gathered there! Solve the missions in various places and get out of there until the next morning through game! Through constant confrontation and urgent confrontation, we will reveal the hidden behind-the-scenes of Korean landmarks!", 79.79, "/2Wmmu1MkqxJ48J7aySET9EKEjXz.jpg", 8.2, 56),
        //        new Movie("/qOQFBEbNqDu7tmfL9wKMc8ECW3L.jpg", "2020-06-20", 96462, "It's Okay to Not Be Okay", "ko", "사이코지만 괜찮아", "Desperate to escape from his emotional baggage and the heavy responsibility he’s had all his life, a psychiatric ward worker begins to heal with help from the unexpected—a woman who writes fairy tales but doesn’t believe in them.", 51.494, "/6CvvTWcw9vSf5Zpgeot2ppE0P2D.jpg", 8.6, 479),
        //        new Movie("/gbmFzIEzl95x7QZfUYdY9QxJFJh.jpg", "2013-03-22", 65282, "Home Alone", "ko", "나 혼자 산다", "It can be a badge of honor to be “single.” “I Live Alone” is a documentary-style South Korean reality series that follows the members of a self-formed club called Rainbow, which is comprised of celebrities who are single and live alone.", 46.562, "/sDWWZyxu5DxRkazIi8yr3WbLWHG.jpg", 7, 4),
        //        new Movie("/bgTm5TTI6uoY0RbLA3Fbl5z32JG.jpg", "2020-04-17", 93846, "The King: Eternal Monarch", "ko", "더 킹 : 영원의 군주", "When a gateway opens to a parallel universe in modern-day Korea, a king must step into another world in search of answers to a long-unanswered mystery.", 35.892, "/7SLlbkzOJb8v9wXVYIcqozx2hxe.jpg", 8.3, 327),
        //        new Movie("/d84gSpBXdl7smdKlwnIWQPewEgs.jpg", "2016-11-16", 67018, "The Legend of the Blue Sea", "ko", "푸른 바다의 전설", "How can a mermaid from the Joseon era survive in modern-day Seoul? Shim Chung is a mermaid who finds herself transplanted to modern times. She is caught by Heo Joon Jae, a charming but cold con artist who is the doppelgänger for Kim Moon, the son of a nobleman from the Joseon Dynasty. But in the present time, Joon Jae works with Jo Nam Doo, a skilled conman who guides Joon Jae to become a genius scammer. But Joon Jae’s friend, Cha Shi Ah, who works as a researcher at KAIST, may be Chung’s only hope for surviving in her strange new world.", 32.003, "/vhBdwKSYOvops4o68X1zNXqEDF1.jpg", 6.6, 58),
        //        new Movie("/wrK5jaWEJS64coFH3ZvVzq2llxB.jpg", "2020-06-19", 98827, "Backstreet Rookie", "ko", "편의점 샛별이", "It tells an unpredictable 24-hour love story of the four-dimensional innocent girl Jung Saet Byeol who was once a troublemaker and the adorkable caring male store manager, Choi Dae Hyun, in the context of a convenience store. They have met each other accidentally 4 years ago, back then Saet Byeol asked Dae Hyun to buy cigarettes for them. Until now, Saet Byeol comes to the convenience store Dae Hyun runs for a part-time job, their hilarious romantic story starts.", 31.201, "/rV9wPNgfvNakfSKoPQRIFVBJnqN.jpg", 7.5, 11),
        //        new Movie("/mZsTrylVWYYPkoY793G5G7nBbAa.jpg", "2015-12-05", 70672, "Men on a Mission", "ko", "아는 형님", "Male celebs play make-believe as high schoolers, welcoming star transfer students every week and engaging in battles of witty humor and slapstick.", 30.409, "/a1rnHdqAvEm5NUWJ2SRzBY4Hkt5.jpg", 8.1, 11),
        //        new Movie("/3qSuCdm5G8vAgXDptNmIOmFBjlU.jpg", "2019-04-18", 87527, "My First First Love", "ko", "첫사랑은 처음이라서", "Due to various personal reasons, a group of Yun Tae-o’s friends move into his house, where they experience love, friendship, and everything in between.", 29.491, "/oTE13yLKzpNfGxdUcyEV6Am4WP2.jpg", 8.3, 339),
        //        new Movie("/dUyx4zi3rzmFoQeyBQlnDRVujwB.jpg", "2016-12-02", 67915, "Goblin", "ko", "쓸쓸하고 찬란하神-도깨비", "Kim Shin is an immortal “goblin,” and has the rather honorable title of being the Protector of Souls. His roommate Wang Yeo also happens to have the equally lofty, if thoroughly opposing, title of Angel of Death, and he acts as the storied grim reaper that claims souls. However, both these devilishly handsome angels have a problem: Wang Yeo has amnesia and Kim Shin wants to end his own (immortal) life. Unfortunately for goblins, the only way to defeat immortality is to marry a human bride. For that purpose, Kim Shin decides to win over Ji Eun Tak an optimistic high school girl who he thinks will be the priestess that ends his cursed existence. Now, once responsible for protecting souls and watching them pass, Kim Shin now tries to send his own to the afterlife. But when a slightly complicated method of suicide starts turning into true love, will our immortal goblin begin to regret his decision--where acting on that very love ultimately means the end of his life?", 28.327, "/76EsqOwwfmJ0qRBJzrC1C8VgoJc.jpg", 8.7, 1145),
        //        new Movie("/8bgggmXgNjIc0rlSKvB2JLTvQsi.jpg", "2014-07-11", 61738, "Hi! School - Love On", "ko", "하이스쿨 : 러브온", "High school may be tough, but Woo Hyun (Nam Woo Hyun) has a guardian angel looking over him — literally. Disguised as a naive high schooler, Lee Seul Bi (Kim Sae Ron) descends from the heavens to protect Woo Hyun's life, but discovers she's got a thing or two to learn about life as a teenager, including the pains of falling in love. Can this cherubic guardian protect the apple of her eye and also manage to survive high school?", 28.23, "/9XUMRNRxK89fWZ4DMtpdlJwKeNP.jpg", 7.8, 315),
        //        new Movie("/tP1iwq4VzDiL1G9M6Vz57zWd5LH.jpg", "2020-02-22", 97219, "Hi Bye, Mama!", "ko", "하이바이, 마마!", "When the ghost of a woman gains a second chance at life for 49 days, she reappears in front of her remarried husband and young daughter.", 27.268, "/mc5nLj2EM480d6tlxKsj2GRfsDC.jpg", 8, 262),
        //        new Movie("/8NK9un1DPUTgRzGtJHMvpdIB5Ay.jpg", "2020-10-17", 99048, "Start-Up", "ko", "스타트업", "Needing to make $90k to open her own business, Seo Dal Mi drops out of a university and takes up part-time work. She dreams of becoming someone like Steve Jobs. Nam Do San is the founder of Samsan Tech. He is excellent with mathematics. He started Samsan Tech two years ago, but the company is not doing well. Somehow, Nam Do San becomes Seo Dal Mi’s first love. They cheer each others start and growth.", 25.414, "/hxJQ3A2wtreuWDnVBbzzXI3YlOE.jpg", 8.1, 8),
        //        new Movie("", "2015-01-07", 62266, "Kill Me, Heal Me", "ko", "킬미, 힐미", "Cha Do Hyun is a rich heir to a family company with one major problem. Due to suppressed childhood trauma, he suffers from dissociative identity disorder manifested in 7 unique personalities who are out of his control. In order to overcome this disorder in secret, he hires a first year medical resident to help him heal by killing off each personality one by one.", 25.02, "/dNH6NO0akHMIqbq5EC4qnCeeuC6.jpg", 8.6, 28),
        //        new Movie("/mN5EK6CH9TmnIB5OBXHTtNBsfDL.jpg", "2005-12-14", 6074, "My Girl", "ko", "마이걸", "Gong Chan is the wealthy, unattached heir to a large company. Having lost both his parents, he is devoted to what remains of his family, particularly his ailing grandfather. After deciding to cut off his only daughter after disapproving of her marriage, the old man is plagued with guilt since the couple was killed soon after he lost touch. By chance, Gong Chan meets a woman who resembles his lost aunt and is inspired to use her to fulfill his grandfather's last wish. The woman, Yoo Rin is the daughter of a compulsive gambler and is constantly on the run, so when Gong Chan offers her this opportunity, she cannot afford to refuse. After Yoo Rin moves in with the family, Gong Chan finds himself drawn to her and a forbidden attraction springs up between them.", 24.828, "/72Su8fJNHMidt9wCcVWKkLJzHrS.jpg", 7.3, 12),
        //        new Movie("/cCAEmVxhOI2vdxCLh9POAtqc2rr.jpg", "2006-05-15", 4734, "Jumong", "ko", "주몽", "Jumong examines the life of Jumong Taewang, founder of the kingdom of Goguryeo. Few details have been found in the historical record about Jumong, so much of the series is fictionalized. The fantastic elements surrounding the original Jumong legend have been replaced with events more grounded in reality.", 24.129, "/tJI1XZtiECE6gz5MXj883eFv35E.jpg", 8.5, 8),
        //        new Movie("/brdHK7HwwGwl1Bk3f6T8rkmkBVY.jpg", "2015-05-15", 62669, "Orange Marmalade", "ko", "오렌지 마말레이드", "Despite a 200-year-old treaty between humans and vampires, both races still don't get along. Amidst the looming tension, Jung Jae Min, a posh yet kindhearted high school student, quickly falls for the mysterious new girl Baek Ma Ri. But can Ma Ri conceal her true vampire identity and give love an honest chance? If these star-crossed lovers can find the courage to make the leap, Jae Min and Ma Ri may just be the key to a final resolution between humans and vampires...", 22.115, "/4y59CKPFxdz51BN3K4SeeO5Ift0.jpg", 7.7, 9),
        //        new Movie("/aFmqXViWzIKmhR8Cy4QDqPU6pIL.jpg", "2019-01-25", 70593, "Kingdom", "ko", "킹덤", "In this zombie thriller set in Korea's medieval Joseon dynasty, a crown prince is sent on a suicide mission to investigate a mysterious outbreak.", 21.889, "/AsICtiVtz4icMQQRwDvOzfaTzjK.jpg", 8.2, 361),
        //        new Movie("/zVnaKKTNYboGyMoXilSaVNeUAn3.jpg", "2005-04-23", 5092, "Infinite Challenge", "ko", "무한도전", "Infinite Challenge has been reported as the first 'Real-Variety' show in Korean television history. The program is largely unscripted, and follows a similar format of challenge-based Reality Television programs, familiar to the audiences in the West, but the challenges are often silly, absurd, or impossible to achieve, so the program takes on the aspect of a satirical comedy variety show, rather than a more standard reality or contest program. In order to achieve its comedic purposes its 6 hosts and staff continuously proclaim, the elements of this show are the 3-Ds, Dirty, Dangerous, and Difficult.", 20.584, "/3ZIPTvMnzI5ThmdGeEYQFxJV5Sg.jpg", 7.3, 12)
        //    };
        }

        static IEnumerable<Genre> GetPreconfiguredGenres()
        {
            return new List<Genre>()
            {
                new Genre(28,"Action"),
                new Genre(12,"Adventure"),
                new Genre(14,"Fantasy"),
                new Genre(36,"History"),
                new Genre(27,"Horror"),
                new Genre(10402,"Music"),
                new Genre(9648,"Mystery"),
                new Genre(10749,"Romance"),
                new Genre(878,"Science Fiction"),
                new Genre(10770,"TV Movie"),
                new Genre(53,"Thriller"),
                new Genre(10752,"War"),
                new Genre(37,"Western"),
                new Genre(10759,"Action & Adventure"),
                new Genre(16,"Animation"),
                new Genre(35,"Comedy"),
                new Genre(80,"Crime"),
                new Genre(99,"Documentary"),
                new Genre(18,"Drama"),
                new Genre(10751,"Family"),
                new Genre(10762,"Kids"),
                new Genre(10763,"News"),
                new Genre(10764,"Reality"),
                new Genre(10765,"Sci-Fi & Fantasy"),
                new Genre(10766,"Soap"),
                new Genre(10767,"Talk"),
                new Genre(10768,"War & Politics")
            };
        }

        static IEnumerable<MovieGenre> GetPreconfiguredMovieGenres()
        {
            return new List<MovieGenre>()
            {
                new MovieGenre(89641 ,  18),
                new MovieGenre(89641 ,  10765),
                new MovieGenre(16420 ,  35),
                new MovieGenre(16420 ,  18),
                new MovieGenre(33238 ,  35),
                new MovieGenre(33238 ,  10764),
                new MovieGenre(96462 ,  18),
                new MovieGenre(96462 ,  35),
                new MovieGenre(65282 ,  10764),
                new MovieGenre(93846 ,  18),
                new MovieGenre(93846 ,  10765),
                new MovieGenre(67018 ,  35),
                new MovieGenre(67018 ,  18),
                new MovieGenre(67018 ,  10765),
                new MovieGenre(98827 ,  35),
                new MovieGenre(70672 ,  10764),
                new MovieGenre(70672 ,  35),
                new MovieGenre(87527 ,  18),
                new MovieGenre(67915 ,  18),
                new MovieGenre(67915 ,  10765),
                new MovieGenre(61738 ,  10765),
                new MovieGenre(97219 ,  10765),
                new MovieGenre(97219 ,  35),
                new MovieGenre(97219 ,  18),
                new MovieGenre(99048 ,  18),
                new MovieGenre(99048 ,  35),
                new MovieGenre(62266 ,  35),
                new MovieGenre(62266 ,  18),
                new MovieGenre(62266 ,  9648),
                new MovieGenre(6074  ,  35),
                new MovieGenre(6074  , 18),
                new MovieGenre(4734  ,  18),
                new MovieGenre(4734  , 10768),
                new MovieGenre(62669 ,  14),
                new MovieGenre(62669 ,  10749),
                new MovieGenre(70593 ,  18),
                new MovieGenre(70593 , 10759),
                new MovieGenre(70593 ,  9648),
                new MovieGenre(5092  ,  35),
                new MovieGenre(5092  , 10764)
            };
        }
    }
}
