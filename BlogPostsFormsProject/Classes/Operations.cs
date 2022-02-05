using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPostsFormsProject.Data;
using BlogPostsFormsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsFormsProject.Classes
{
    public class Operations
    {
        public static async Task<Blogs> Example1()
        {
            Debug.WriteLine(nameof(Example1));

            await using var context =  new Context();

            Blogs singleBlog = await context
                .Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.PostTag)
                .ThenInclude(postTags => postTags.Tags)
                .FirstOrDefaultAsync();

            foreach (var post in singleBlog.Posts)
            {

                if (post.PostTag.Count <= 0) continue;

                Debug.WriteLine(post.Title);

                Debug.WriteLine($"\t{post.Content}");

                foreach (var tag in post.PostTag)
                {
                    Debug.WriteLine($"\t\t{tag.TagsId}");
                }

            }

            Debug.WriteLine("");

            return singleBlog;

        }
        public static async Task<List<Blogs>> Example2()
        {
            Debug.WriteLine(nameof(Example2));
            await using var context = new Context();

            List<Blogs> blogs = await context
                .Blogs
                .Include(blog => blog.Posts)
                .ThenInclude(post => post.PostTag)
                .ThenInclude(postTags => postTags.Tags)
                .ToListAsync();

            foreach (var blog in blogs)
            {
                Debug.WriteLine($"Name: {blog.Name,-20}Url:{blog.Url} {blog.DateModified:d}");
                foreach (var blogPost in blog.Posts)
                {
                    Debug.WriteLine($"Post title: {blogPost.Title}");
                    Debug.WriteLine($"Content: [{blogPost.Content}]");
                }

                Debug.WriteLine("");
            }


            Debug.WriteLine("");

            return blogs;
        }
    }
}
