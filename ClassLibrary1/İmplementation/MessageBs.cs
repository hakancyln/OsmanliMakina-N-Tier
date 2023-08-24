using AutoMapper;
using Microsoft.AspNetCore.Http;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.MessageDto;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class MessageBs : IMessageBs
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageBs(IMessageRepository messageRepository,IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var message = await _messageRepository.GetByIDAsync(id);

            await _messageRepository.DeleteAsync(message);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<MessageGetDto>>> GetAsync()
        {
            var message = await _messageRepository.GetAllAsync();
            if (message.Count > 0)
            {
                var messageList = _mapper.Map<List<MessageGetDto>>(message);
                var response = ApiResponse<List<MessageGetDto>>.Success(StatusCodes.Status200OK, messageList);

                return response;
            }

            throw new NotFoundException("Mesaj Bulunamadı.");
        }

        public async Task<ApiResponse<MessageGetDto>> GetByIDAsync(int messageId)
        {
            var message = await _messageRepository.GetByIDAsync(messageId);

            if (message != null)
            {
                var dto = _mapper.Map<MessageGetDto>(message);
                return ApiResponse<MessageGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<Message>> InsertAsync(MessagePostDto p)
        {
            if (p == null)
                throw new BadRequestException("Eklenecek Mesaj Yok");

            var message = _mapper.Map<Message>(p);
            var insertedMessage = await _messageRepository.InsertAsync(message);
            return ApiResponse<Message>.Success(StatusCodes.Status200OK, insertedMessage);
        }
    }
}
