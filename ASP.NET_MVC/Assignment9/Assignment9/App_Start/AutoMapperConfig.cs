using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment9
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // AutoMapper create map statements - using AutoMapper static API
            // Mapper.Initialize(cfg => cfg.CreateMap< FROM , TO >());
            // Add map creation statements here
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                // Add more below...

                /*Get All Method Automappers*/
                cfg.CreateMap<Models.Artist, Controllers.ArtistBase>();
                cfg.CreateMap<Models.Album, Controllers.AlbumBase>();
                cfg.CreateMap<Models.Genre, Controllers.GenreBase>();
                cfg.CreateMap<Models.Track, Controllers.TrackBase>();

                /*Get One Method Automappers*/
                cfg.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();
                cfg.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
                cfg.CreateMap<Models.Track, Controllers.TrackWithDetail>();
                cfg.CreateMap<Models.Track, Controllers.TrackAudio>();

                /*Add New Method Automappers*/
                cfg.CreateMap<Controllers.ArtistAdd, Models.Artist>();
                cfg.CreateMap<Controllers.AlbumAdd, Models.Album>();
                cfg.CreateMap<Controllers.TrackAdd, Models.Track>();

                /*Media contents*/
                cfg.CreateMap<Models.MediaItem, Controllers.MediaItemBase>();
                cfg.CreateMap<Models.MediaItem, Controllers.MediaContent>();
                cfg.CreateMap<Models.Artist, Controllers.ArtistWithContentStringIds>();

                //Optional
                cfg.CreateMap<Controllers.TrackWithDetail, Controllers.TrackEditForm>();
                
            });
        }
    }
}