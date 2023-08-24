using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.MessageDto;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface IMessageBs
    {
        Task<ApiResponse<List<MessageGetDto>>> GetAsync();
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<Message>> InsertAsync(MessagePostDto p);
        Task<ApiResponse<MessageGetDto>> GetByIDAsync(int messageId);

    }
}
