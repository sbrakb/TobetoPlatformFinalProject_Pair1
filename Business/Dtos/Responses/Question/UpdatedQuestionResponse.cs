﻿namespace Business.Dtos.Responses.Question
{
    public class UpdatedQuestionResponse
    {
        public Guid Id { get; set; }
        public Guid TrueAnswerId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
