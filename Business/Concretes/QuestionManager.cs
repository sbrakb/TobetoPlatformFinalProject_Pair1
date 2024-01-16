﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Question;
using Business.Dtos.Responses.Question;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class QuestionManager: IQuestionService
    {
        IMapper _mapper;
        IQuestionDal _questionDal;

        public QuestionManager(IMapper mapper, IQuestionDal questionDal)
        {
            _mapper = mapper;
            _questionDal = questionDal;
        }

        public async Task<CreatedQuestionResponse> AddAsync(CreateQuestionRequest createQuestionRequest)
        {
            Question question = _mapper.Map<Question>(createQuestionRequest);
            var createdQuestion = await _questionDal.AddAsync(question);
            CreatedQuestionResponse createdQuestionResponse = _mapper.Map<CreatedQuestionResponse>(createdQuestion);
            return createdQuestionResponse;
        }

        public async Task<DeletedQuestionResponse> DeleteAsync(DeleteQuestionRequest deleteQuestionRequest)
        {
            Question question = await _questionDal.GetAsync(q => q.Id == deleteQuestionRequest.Id);
            var deletedQuestion = await _questionDal.DeleteAsync(question);
            DeletedQuestionResponse deletedQuestionResponse = _mapper.Map<DeletedQuestionResponse>(deletedQuestion);
            return deletedQuestionResponse;
        }

        public async Task<GetQuestionResponse> GetByIdAsync(GetQuestionRequest getQuestionRequest)
        {
             var result = await _questionDal.GetAsync(q => q.Id == getQuestionRequest.Id);
             return _mapper.Map<GetQuestionResponse>(result);
        }

        public async Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _questionDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListQuestionResponse>>(result);
        }

        public async Task<UpdatedQuestionResponse> UpdateAsync(UpdateQuestionRequest updateQuestionRequest)
        {
            Question question = _mapper.Map<Question>(updateQuestionRequest);
            var updatedQuestion = await _questionDal.UpdateAsync(question);
            UpdatedQuestionResponse updatedQuestionResponse = _mapper.Map<UpdatedQuestionResponse>(updatedQuestion);
            return updatedQuestionResponse;
        }
    }
}
