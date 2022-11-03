﻿namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Services;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private ArticleService _articleService;
        
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            return Created($"/article/{article.Id}", _articleService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return _articleService.GetByID(id);
        }
    }
}