using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment9.Models;
using System.Security.Claims;
using System.Data.Entity;

namespace Assignment9.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // Declare a property to hold the user account for the current request
        // Can use this property here in the Manager class to control logic and flow
        // Can also use this property in a controller 
        // Can also use this property in a view; for best results, 
        // near the top of the view, add this statement:
        // var userAccount = new ConditionalMenu.Controllers.UserAccount(User as System.Security.Claims.ClaimsPrincipal);
        // Then, you can use "userAccount" anywhere in the view to render content
        public UserAccount UserAccount { get; private set; }

        public Manager()
        {
            // If necessary, add constructor code here

            // Initialize the UserAccount property
            UserAccount = new UserAccount(HttpContext.Current.User as ClaimsPrincipal);

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        /*
         * Get all methods
         * 1. ArtistGetAll()
         * 2. AlbumGetAll()
         * 3. TrackGetAll()
         * 4. GenreGetAll()
         */
        public IEnumerable<ArtistBase> ArtistGetAll()
        {
            return Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBase>>(ds.Artists.OrderBy(ar => ar.Id));  
        }
        public IEnumerable<AlbumBase> AlbumGetAll()
        {
            return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBase>>(ds.Albums.OrderBy(al => al.Id));
        }
        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(ds.Tracks.OrderBy(t => t.Id));
        }
        public IEnumerable<GenreBase> GenreGetAll()
        {
            return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBase>>(ds.Genres.OrderBy(gn => gn.Name));
        }

        /*StringIds*/
        public ArtistWithContentStringIds ArtistGetByWithContentInfo(int? id)
        {
            var o = ds.Artists.Include("MediaItems").SingleOrDefault(a => a.Id == id);

            return (o == null) ? null : Mapper.Map<Artist, ArtistWithContentStringIds>(o);
        }
        /*
         * GetDetailMethod
         */
        public ArtistWithDetail ArtistGetById(int? id)
        {
            var o = ds.Artists.SingleOrDefault(ar => ar.Id == id);

            return (o == null) ? null : Mapper.Map<Artist, ArtistWithDetail>(o);    
        }
        public AlbumWithDetail AlbumGetById(int? id)
        {
            var o = ds.Albums.SingleOrDefault(al => al.Id == id);

            return (o == null) ? null : Mapper.Map<Album, AlbumWithDetail>(o);
        }
        public TrackWithDetail TrackGetById(int? id)
        {
            var o = ds.Tracks.SingleOrDefault(t => t.Id == id);
            
            return (o == null) ? null : Mapper.Map<Track, TrackWithDetail>(o);
        }

        public TrackAudio TrackAudioGetById(int? id)
        {
            var o = ds.Tracks.Find(id);

            return (o == null) ? null : Mapper.Map<Track, TrackAudio>(o);
        }
        
        public MediaContent ArtistGetContentById(string stringId)
        {
            var o = ds.MediaItems.SingleOrDefault(a => a.StringId == stringId);

            return (o == null) ? null : Mapper.Map<MediaItem, MediaContent>(o);
        }
        /*
         * Create methods    
         */
        public ArtistWithDetail ArtistAdd(ArtistAdd newItem)
        {
            var addedItem = ds.Artists.Add(Mapper.Map<ArtistAdd, Artist>(newItem));
            var tempGenre = ds.Genres.Find(newItem.GenreId);

            addedItem.Genre = tempGenre.Name;

            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<Artist, ArtistWithDetail>(addedItem);
        }
        public AlbumWithDetail AlbumAdd(AlbumAdd newItem)
        {
            var addedItem = ds.Albums.Add(Mapper.Map<AlbumAdd, Album>(newItem));
            var tempGenre = ds.Genres.Find(newItem.GenreId);
            var tempArtist = ds.Artists.Find(newItem.ArtistId);

            if (addedItem == null)
            {
                return null;
            }

            addedItem.Artists.Add(tempArtist);
            addedItem.Genre = tempGenre.Name;

            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<Album, AlbumWithDetail>(addedItem);
        }
        public TrackWithDetail TrackAdd(int? id, TrackAdd newItem)
        {
            var addedItem = ds.Tracks.Add(Mapper.Map<TrackAdd, Track>(newItem));
            var tempGenre = ds.Genres.Find(newItem.GenreId);
            var tempAlbum = ds.Albums.Find(id);

            byte[] audioBytes = new byte[newItem.AudioUpload.ContentLength];
            newItem.AudioUpload.InputStream.Read(audioBytes, 0, newItem.AudioUpload.ContentLength);

            if (addedItem == null)
            {
                return null;
            }

            addedItem.Albums = new List<Album>();
            addedItem.Albums.Add(tempAlbum);
            addedItem.Genre = tempGenre.Name;
            addedItem.Clerk = UserAccount.Name;
            addedItem.Audio = audioBytes;
            addedItem.AudioContentType = newItem.AudioUpload.ContentType;

            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<Track, TrackWithDetail>(addedItem);
        }
        public ArtistWithDetail ArtistMediaItemAdd(MediaItemAdd newItem)
        {
            var a = ds.Artists.Find(newItem.ArtistId);

            if (a == null)
            {
                return null;
            }
            else
            {
                var addedItem = new MediaItem();
                ds.MediaItems.Add(addedItem);

                addedItem.Caption = newItem.Caption;
                addedItem.artist = a;

                //Handle the uploaded content
                //First, extract the bytes from the HttpPostedFile object
                byte[] contentBytes = new byte[newItem.ContentUpload.ContentLength];
                newItem.ContentUpload.InputStream.Read(contentBytes, 0, newItem.ContentUpload.ContentLength);

                //Then configure the new object's properties
                addedItem.Content = contentBytes;
                addedItem.ContentType = newItem.ContentUpload.ContentType;

                ds.SaveChanges();

                return (addedItem == null) ? null : Mapper.Map<Artist, ArtistWithDetail>(a);
                
            }
        }
        /*Delete methods*/
        public bool ArtistDelete(int? id)
        {
            var deleteItem = ds.Artists.Find(id);

            if (deleteItem == null)
            {
                return false;
            }
            else
            {
                ds.Artists.Remove(deleteItem);
                ds.SaveChanges();

                return true;
            }
        }
        public bool AlbumDelete(int? id)
        {
            var deleteItem = ds.Albums.Find(id);

            if(deleteItem == null)
            {
                return false;
            }
            else
            {
                ds.Albums.Remove(deleteItem);
                ds.SaveChanges();

                return true;
            }
        }

        public  bool TrackDelete(int? id)
        {
            var deleteItem = ds.Tracks.Find(id);

            if(deleteItem == null)
            {
                return false;
            }
            else
            {
                ds.Tracks.Remove(deleteItem);
                ds.SaveChanges();

                return true;
            }

        }
        /*
         * Edit Methods
         */
        public TrackWithDetail TrackEdit(TrackEdit newItem)
        {
            var o = ds.Tracks.Find(newItem.Id);
            byte[] audioBytes = new byte[newItem.AudioUpload.ContentLength];
            newItem.AudioUpload.InputStream.Read(audioBytes, 0, newItem.AudioUpload.ContentLength);
            if (o == null)
            {
                return null;
            }
            else
            { 
                o.Audio = audioBytes;
                o.AudioContentType = newItem.AudioUpload.ContentType;
                ds.Entry(o).State = EntityState.Modified;
                ds.SaveChanges();

                return Mapper.Map<Track, TrackWithDetail>(o);
            }
        }
        // Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }
        public bool LoadData()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // ############################################################
            // Genre

            if (ds.Genres.Count() == 0)
            {
                // Add genres

                ds.Genres.Add(new Genre { Name = "Alternative" });
                ds.Genres.Add(new Genre { Name = "Classical" });
                ds.Genres.Add(new Genre { Name = "Country" });
                ds.Genres.Add(new Genre { Name = "Easy Listening" });
                ds.Genres.Add(new Genre { Name = "Hip-Hop/Rap" });
                ds.Genres.Add(new Genre { Name = "Jazz" });
                ds.Genres.Add(new Genre { Name = "Pop" });
                ds.Genres.Add(new Genre { Name = "R&B" });
                ds.Genres.Add(new Genre { Name = "Rock" });
                ds.Genres.Add(new Genre { Name = "Soundtrack" });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Artist

            if (ds.Artists.Count() == 0)
            {
                // Add artists

                ds.Artists.Add(new Artist
                {
                    Name = "The Beatles",
                    BirthOrStartDate = new DateTime(1962, 8, 15),
                    Executive = user,
                    Genre = "Pop",
                    UrlArtist = "https://upload.wikimedia.org/wikipedia/commons/9/9f/Beatles_ad_1965_just_the_beatles_crop.jpg"
                });

                ds.Artists.Add(new Artist
                {
                    Name = "Adele",
                    BirthName = "Adele Adkins",
                    BirthOrStartDate = new DateTime(1988, 5, 5),
                    Executive = user,
                    Genre = "Pop",
                    UrlArtist = "http://www.billboard.com/files/styles/article_main_image/public/media/Adele-2015-close-up-XL_Columbia-billboard-650.jpg"
                });

                ds.Artists.Add(new Artist
                {
                    Name = "Bryan Adams",
                    BirthOrStartDate = new DateTime(1959, 11, 5),
                    Executive = user,
                    Genre = "Rock",
                    UrlArtist = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Bryan_Adams_Hamburg_MG_0631_flickr.jpg"
                });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Album

            if (ds.Albums.Count() == 0)
            {
                // Add albums

                // For Bryan Adams
                var bryan = ds.Artists.SingleOrDefault(a => a.Name == "Bryan Adams");

                ds.Albums.Add(new Album
                {
                    Artists = new List<Artist> { bryan },
                    Name = "Reckless",
                    ReleaseDate = new DateTime(1984, 11, 5),
                    Coordinator = user,
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/en/5/56/Bryan_Adams_-_Reckless.jpg"
                });

                ds.Albums.Add(new Album
                {
                    Artists = new List<Artist> { bryan },
                    Name = "So Far So Good",
                    ReleaseDate = new DateTime(1993, 11, 2),
                    Coordinator = user,
                    Genre = "Rock",
                    UrlAlbum = "https://upload.wikimedia.org/wikipedia/pt/a/ab/So_Far_so_Good_capa.jpg"
                });

                ds.SaveChanges();
                done = true;
            }

            // ############################################################
            // Track

            if (ds.Tracks.Count() == 0)
            {
                // Add tracks

                // For Reckless
                var reck = ds.Albums.SingleOrDefault(a => a.Name == "Reckless");

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Run To You",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock",
                    AudioContentType = "audio/mp3",
                    Audio = new byte[362183]
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Heaven",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                    
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Somebody",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Summer of '69",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { reck },
                    Name = "Kids Wanna Rock",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                // For Reckless
                var so = ds.Albums.SingleOrDefault(a => a.Name == "So Far So Good");

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "Straight from the Heart",
                    Composers = "Bryan Adams, Eric Kagna",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "It's Only Love",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "This Time",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "(Everything I Do) I Do It for You",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.Tracks.Add(new Track
                {
                    Albums = new List<Album> { so },
                    Name = "Heat of the Night",
                    Composers = "Bryan Adams, Jim Vallance",
                    Clerk = user,
                    Genre = "Rock"
                });

                ds.SaveChanges();
                done = true;
            }
            if(ds.RoleClaims.Count() == 0)
            {
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Executive"
                });
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Coordinator"
                });
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Clerk"
                });
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Finance"
                });
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Marketing"
                });
                ds.RoleClaims.Add(new RoleClaim
                {
                    Name = "Staff"
                });
                ds.SaveChanges();
                done = true;
            }
            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.Tracks)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Albums)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Artists)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                ds.SaveChanges();

                foreach (var e in ds.Genres)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
                foreach(var e in ds.MediaItems)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }
          
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    // New "UserAccount" class for the authenticated user
    // Includes many convenient members to make it easier to render user account info
    // Study the properties and methods, and think about how you could use it
    public class UserAccount
    {
        // Constructor, pass in the security principal
        public UserAccount(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }
        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }
        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }
        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        // Add other role-checking properties here as needed
        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

}