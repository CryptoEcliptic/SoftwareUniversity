const Article = require('../models').Article;
const User = require('../models').User;
const Comment = require('../models').Comment;

module.exports = {
    createGet: (req, res) => {
        res.render('article/create');
    },
    createPost: (req, res) => {
        let articleArgs = req.body;
        let errorMsg = '';

         if(!req.isAuthenticated()){
             errorMsg = 'You should be logged in to make articles!';
         }
         else if(!articleArgs.title){
            errorMsg = 'Invalid title!';
        }
        else if(!articleArgs.content){
            errorMsg = 'Invalid content!';
         }
         if(errorMsg){
             return res.render('article/create', {error: errorMsg});

         }
        let userId = req.user.id;
         articleArgs.authorId = userId;

         Article.create(articleArgs).then(article => {
             res.redirect('/');
         }).catch(err => {
             console.log(err.message);
             res.render('article/create', {error: err.message});
         });
    },

    details: (req, res) => {
        let articleId = req.params.id;
        Article.findById(articleId, {
            include: [
                {
                    model: User,
                }
            ]
            }).then(articles => {
                res.render('article/details', articles.dataValues)
        });
    },
    commentAddPost: (req, res) => {
        let body = req.body;
        let author = req.user;
        let articleId = req.params.articleId;


        let comment = {
            content: body.content,
            authorId: author.id,
            articleId: articleId
        };
        Comment.create(comment).then(() => {
            res.redirect(`/article/details/${articleId}`);
        });


    },

    editGet: function (req, res) {
       let articleId = req.params.id;
       Article
           .findById(articleId)
           .then(articles => {
           res.render('article/edit', articles.dataValues)})
    },
    editPost: function (req, res) {
        let articleArgs = req.body;
        let articleId = req.params.id;
        Article
            .findById(articleId)
            .then(articles => {
                articles.update(articleArgs)
                    .then(() => {
                        res.redirect('/');
                        })
            })
    },

    deleteGet: function (req, res) {
        let articleId = req.params.id;
        Article
            .findById(articleId)
            .then(articles => {
                res.render('article/delete', articles.dataValues)})
    },
    deletePost: function (req, res) {
        let articleId = req.params.id;
        Article
            .findById(articleId)
            .then(articles => {
                articles
                    .destroy()
                    .then(() => {
                        res.redirect('/');
                    })
            })
    }
};