﻿using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class ArticleService
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public ArticleService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        public Article Create(Article article)
        {
            if (article.UserName != null)
            {
                if (!_userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    _userStore.Save(new User(article.UserName));
                }

                _articleStore.Save(article);
            }

            return article;
        }

        public List<Article> List()
        {
            return _articleStore.GetAll();
        }

        public Article GetByID(Guid id)
        {
            return _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
        }
    }
}
