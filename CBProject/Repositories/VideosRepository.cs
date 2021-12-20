﻿using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class VideosRepository : IRepository<Video>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoriesRepository _categoriesRepository;
        private bool disposedValue;
        public VideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
            this._categoriesRepository = unitOfWork.Categories;
        }
        public ICollection<Video> GetVideosCC(string userId)
        {
            return this.GetAll()
                .Where(v => v.CreatorId == userId)
                .ToList();
        }
        public void Add(Video video)
        {
            if(video == null)
                throw new ArgumentNullException(nameof(video));

            this._context.Videos.Add(video);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var video = this.Get(id);
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            this._context.Videos.Remove(video);
        }
        public Video Get(int? id)
        {
            return this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .SingleOrDefault(v => v.ID == id);
        }
        public ICollection<Video> GetAll()
        {
            return this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .ToList();
        }
        public ICollection<Video> GetAllEmpty()
        {
            
            return this._context.Videos.ToList();
        }
        public Video GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Videos.Find(id);
        }
        public ICollection<Video> GetOtherVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return _context.Videos
                .Where(v => !category.Videos.Contains(v))
                .ToList();
        }
        public ICollection<Video> GetVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return _context.Videos
                .Where(v => category.Videos.Contains(v))
                .ToList();
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public void Update(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            this._context.Entry(video).State = EntityState.Modified;
        }
        public async Task<Video> GetAsync(int? id)
        {
            return await this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .SingleOrDefaultAsync(v => v.ID == id);
        }
        public async Task<Video> GetEmptyAsync(int? id)
        {
            return await this._context.Videos
                .SingleOrDefaultAsync(v => v.ID == id);
        }
        public async Task<ICollection<Video>> GetAllAsync()
        {
            return await this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetAllEmptyAsync()
        {
            return await this._context.Videos
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetOtherVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return await _context.Videos
                .Where(v => !category.Videos.Contains(v))
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return await _context.Videos
                .Where(v => category.Videos.Contains(v))
                .ToListAsync();
        }


        public async Task<float> GetRatingsAverageAsync(int videoId)
        {
            var ratings = await this.GetRetingsAsync(videoId);
            float sum = 0;
            foreach (var rate in ratings)
            {
                sum += rate.Rate;
            }
            return sum / ratings.Count;
        }
        public async Task<ICollection<Rating>> GetRetingsAsync(int videoId)
        {
            var ratingsToVideos = await this._context.RatingsToVideos
                .Where(r => r.VideoId == videoId)
                .Select(r => r.RatingId)
                .ToListAsync();
            return await this._context.Ratings
                .Where(r => ratingsToVideos.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddRatingAsync(int videoId, string userId, float rate)
        {
            var rater = await this._context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (rater == null)
                throw new NullReferenceException(nameof(rater));
            var myRate = new Rating()
            {
                Rate = rate,
                Rater = rater
            };
            this._context.Ratings.Add(myRate);
            await this._context.SaveChangesAsync();
            var rateToVideo = new RatingToVideo()
            {
                Rating = await this._context.Ratings.FirstOrDefaultAsync(r => r.Rate == rate && r.Rater.Id.Equals(rater.Id)),
                Video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId)
            };
            this._context.RatingsToVideos.Add(rateToVideo);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveRatingAsync(int videoId, string userId, float rate)
        {
            var myRate = await this._context.Ratings
                            .FirstOrDefaultAsync(r => r.Rater.Id.Equals(userId) && r.Rate == rate);
            if (myRate == null)
                throw new NullReferenceException(nameof(myRate));
            var rateToVideo = await this._context.RatingsToVideos
                .FirstOrDefaultAsync(r => r.VideoId == videoId && r.Rating.ID == myRate.ID);
            if (rateToVideo == null)
                throw new NullReferenceException(nameof(rateToVideo));
            this._context.RatingsToVideos.Remove(rateToVideo);
            this._context.Ratings.Remove(myRate);
            await this._context.SaveChangesAsync();
        }

        public async Task<ICollection<Review>> GetReviewsAsync(int videoId)
        {
            var reviewsToVideos = await this._context.ReviewsToVideos
                .Where(r => r.VideoId == videoId)
                .Select(r => r.ReviewId)
                .ToListAsync();
            return await this._context.Reviews
                .Where(r => reviewsToVideos.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddReviewAsync(int videoId, string userId, string comment)
        {
            var reviewer = await this._context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (reviewer == null)
                throw new NullReferenceException(nameof(reviewer));
            var review = new Review()
            {
                Reviewer = reviewer,
                Comment = comment
            };
            this._context.Reviews.Add(review);
            await this._context.SaveChangesAsync();
            var reviewToVideo = new ReviewToVideo()
            {
                Review = await this._context.Reviews.FirstOrDefaultAsync(r => r.Reviewer.Id.Equals(userId) && r.Comment.Equals(comment)),
                Video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId)
            };
            this._context.ReviewsToVideos.Add(reviewToVideo);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveReviewAsync(int videoId, string userId, string comment)
        {
            var review = await this._context.Reviews
                .FirstOrDefaultAsync(r => r.Comment.Equals(comment) && r.Reviewer.Id.Equals(userId));
            if (review == null)
                throw new NullReferenceException(nameof(review));
            var reviewToVideo = await this._context.ReviewsToVideos
                .FirstOrDefaultAsync(r => r.Video.ID == videoId && r.Review.ID == review.ID);
            if (reviewToVideo == null)
                throw new NullReferenceException(nameof(reviewToVideo));
            this._context.ReviewsToVideos.Remove(reviewToVideo);
            this._context.Reviews.Remove(review);
            await this._context.SaveChangesAsync();
        }

        public async Task<ICollection<Tag>> GetTagsAsync(int videoId)
        {
            var tagsToVideos = await this._context.TagsToVideos
                .Where(t => t.VideoId == videoId)
                .Select(t => t.TagId)
                .ToListAsync();
            return await this._context.Tags
                .Where(t => tagsToVideos.Contains(t.ID))
                .ToListAsync();
        }
        public async Task AddTagAsync(int videoId, string title)
        {
            var tag = new Tag()
            {
                Title = title
            };
            this._context.Tags.Add(tag);
            await this._context.SaveChangesAsync();
            var TagToVideo = new TagToVideo()
            {
                Video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId),
                Tag = await this._context.Tags.FirstOrDefaultAsync(t => t.Title.Equals(title))
            };
            this._context.TagsToVideos.Add(TagToVideo);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveTagAsync(int videoId, string title)
        {
            var tag = await this._context.Tags.FirstOrDefaultAsync(t => t.Title.Equals(title));
            if (tag == null)
                throw new NullReferenceException(nameof(tag));
            var tagToVideo = await this._context.TagsToVideos
                .FirstOrDefaultAsync(t => t.VideoId == videoId && t.Tag.Title.Equals(title));
            if (tagToVideo == null)
                throw new NullReferenceException(nameof(tagToVideo));
            this._context.TagsToVideos.Remove(tagToVideo);
            this._context.Tags.Remove(tag);
            await this._context.SaveChangesAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                    this._categoriesRepository.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}