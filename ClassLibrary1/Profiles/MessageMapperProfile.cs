using AutoMapper;
using Osm.ModelLayer.Dtos.MessageDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class MessageMapperProfile : Profile
    {
        public MessageMapperProfile()
        {
            CreateMap<Message, MessageGetDto>();
            CreateMap<MessagePostDto, Message>();
            CreateMap<MessagePutDto, Message>();
        }

    }
}
