using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment8
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

                /*Get All Mappers*/
                cfg.CreateMap<Models.Album, Controllers.AlbumBase>();
                cfg.CreateMap<Models.Artist, Controllers.ArtistBase>();
                cfg.CreateMap<Models.Track, Controllers.TrackBase>();
                cfg.CreateMap<Models.Genre, Controllers.GenreBase>();

                /*Get One Detail Mappers*/
                cfg.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();
                cfg.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
                cfg.CreateMap<Models.Track, Controllers.TrackWithDetail>();

                /*Create Mappers*/
                cfg.CreateMap<Controllers.AlbumAdd, Models.Album>();
                cfg.CreateMap<Controllers.ArtistAdd, Models.Artist>();
                cfg.CreateMap<Controllers.TrackAdd, Models.Track>();

                /*Edit Mappers*/
                cfg.CreateMap<Controllers.TrackBase, Controllers.TrackEditForm>();
                cfg.CreateMap<Controllers.TrackWithDetail, Controllers.TrackEditForm>();
                // Add more below...
            });

        }
    }
}