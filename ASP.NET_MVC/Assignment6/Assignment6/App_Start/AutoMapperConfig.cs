using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment6
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Track, Controllers.TrackBase>();
                cfg.CreateMap<Models.Playlist, Controllers.PlaylistBase>();
                cfg.CreateMap<Models.Playlist, Controllers.PlaylistWithDetail>();

                //Optional
                cfg.CreateMap<Controllers.PlaylistBase, Controllers.PlaylistEditTracksForm>();
                
            });


        }
    }
}