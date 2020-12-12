using DotNetTeam7API.Data.TMDData;
using DotNetTeam7API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetTeam7API.Data
{
    public class MovieDbSeedConverter
    {
        private static readonly HttpClient client = new HttpClient();

        public static List<Movie> Movies = new List<Movie>();
        public static List<MovieGenre> MovieGenres = new List<MovieGenre>();
        const int PAGES = 40;

        public static async Task Convert()
        {
            Movies.Clear();
            MovieGenres.Clear();

            int page = 1;

            ////////////////test////////////////////////////////////
            SortedSet<int> testGenre = new SortedSet<int>();
            int [] testGenreArray = {
                28,
                12,
                14,
                36,
                27,
                10402,
                9648,
                10749,
                878,
                10770,
                53,
                10752,
                37,
                10759,
                16,
                35,
                80,
                99,
                18,
                10751,
                10762,
                10763,
                10764,
                10765,
                10766,
                10767,
                10768 };
            SortedSet<int> testGENRE = new SortedSet<int>(testGenreArray);
            ////////////////end test////////////////////////////////////

            try
            { 
                using (var httpClient = new HttpClient())
                {
                    while(page <= PAGES)
                    {
                        using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/discover/tv?api_key=4d50e231ebab0b714167607ce53b71f1&language=en-US&with_original_language=ko&page=" + page))
                        {

                            if (!response.StatusCode.Equals(HttpStatusCode.OK))
                                break;

                            string apiResponse = await response.Content.ReadAsStringAsync();

                            Root apiObjects = JsonConvert.DeserializeObject<Root>(apiResponse);

                            foreach (var m in apiObjects.results)
                            {
                                Movies.Add(
                                    new Movie(
                                    m.backdrop_path,
                                    m.first_air_date,
                                    m.id,
                                    m.name,
                                    m.original_language,
                                    m.original_name,
                                    m.overview,
                                    m.popularity,
                                    m.poster_path,
                                    m.vote_average,
                                    m.vote_count
                                    )
                                );

                                HashSet<int> set = new HashSet<int>();

                                foreach (var g in m.genre_ids)
                                {
                                    set.Add(g);
                                    testGenre.Add(g);
                                }

                                ////////////////test////////////////////////////////////
                                if (m.genre_ids.Count != set.Count)
                                {
                                    System.Diagnostics.Debug.WriteLine($@"find duplicated genre id");
                                }
                                ////////////////end test////////////////////////////////////

                                foreach (var g in set)
                                {
                                    MovieGenres.Add(new MovieGenre(m.id, g));

                                }

                            }
                        }
                        ++page;
                    }
                }
            }
            catch (IOException ex)
            {
                //MessageBox.Show(ex.Message);
            }

            ////////////////test////////////////////////////////////
            foreach (var t in testGenre)
            {
                if (testGENRE.Contains(t) == null)
                {
                    System.Diagnostics.Debug.WriteLine($@"could not find genreId in the default genre array");
                }
            }
            ////////////////end-test////////////////////////////////////
        }
    }
}
