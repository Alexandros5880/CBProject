using CBProject.HelperClasses.Interfaces;
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
    public class EbooksRepository : IRepository<Ebook>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public EbooksRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Ebooks.Add(ebook);
        }
        public void Update(Ebook ebook)
        {
           if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Entry(ebook).State = EntityState.Modified;
        }
        public Ebook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Ebooks
                .Include(c => c.Category)
                .Include(e => e.Category)
                .Include(e => e.Creator)
                .FirstOrDefault(e=>e.ID == id);
        }
        public ICollection<Ebook> GetAll()
        {
            return _context.Ebooks
                .Include(c => c.Category).ToList();
        }
        public void Delete(int? id)
        {
           
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = Get(id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(id));
            _context.Ebooks.Remove(ebook);
        }
        public async Task<ICollection<Ebook>> GetAllAsync()
        {

            return await _context.Ebooks
                .Include(c => c.Category).ToListAsync();
        }
        public ICollection<Ebook> GetAllEmpty()
        {
            return _context.Ebooks.ToList();
        }
        public async Task<ICollection<Ebook>> GetAllEmptyAsync()
        {
            return await this._context.Ebooks
                .ToListAsync();

        }
        public async Task<Ebook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await _context.Ebooks
                .Include(c => c.Category)
                 .Include(e => e.Category)
                 .Include(e => e.Creator)
                 .FirstAsync(e => e.ID == id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return ebook;

        }
        public Ebook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Ebooks.FirstOrDefault(e => e.ID == id);
        }
        public async Task<Ebook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return ebook;

        }


        public async Task<int> GetRatingsAverageAsync(int ebookId)
        {
            var ratings = await this.GetRetingsAsync(ebookId);
            var sum = 0;
            foreach(var rate in ratings)
            {
                sum += rate.Rate;
            }
            return sum / ratings.Count;
        }
        public async Task<ICollection<Rating>> GetRetingsAsync(int ebookId)
        {
            var ratingsToEbooks = await this._context.RatingsToEbooks
                .Where(r => r.EbookId == ebookId)
                .Select(r => r.RatingId)
                .ToListAsync();
            return await this._context.Ratings
                .Where(r => ratingsToEbooks.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddRatingAsync(int ebookId, string userId, int rate)
        {
            var rater = await this._context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (rater == null)
                throw new NullReferenceException(nameof(rater));
            var myRate = new Rating()
            {
                Rate = rate,
                Rater = rater
            };
            if (!this._context.Ratings.Contains(myRate))
            {
                this._context.Ratings.Add(myRate);
                await this._context.SaveChangesAsync();
            }
            var rateToEbook = new RatingToEbook()
            {
                Rating = await this._context.Ratings.FirstOrDefaultAsync(r => r.Rate == rate && r.Rater.Id.Equals(rater.Id)),
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId)
            };
            if (!this._context.RatingsToEbooks.Contains(rateToEbook))
            {
                this._context.RatingsToEbooks.Add(rateToEbook);
                await this._context.SaveChangesAsync();
            }
        }
        public async Task RemoveRatingAsync(int ebookId, string userId, int rate)
        {
            var myRate = await this._context.Ratings
                .FirstOrDefaultAsync(r => r.Rater.Id.Equals(userId) && r.Rate == rate);
            if (myRate == null)
                throw new NullReferenceException(nameof(myRate));
            var rateToEbook = await this._context.RatingsToEbooks
                .FirstOrDefaultAsync( r => r.EbookId == ebookId && r.Rating.ID == myRate.ID);
            if (rateToEbook == null)
                throw new NullReferenceException(nameof(rateToEbook));
            this._context.RatingsToEbooks.Remove(rateToEbook);
            this._context.Ratings.Remove(myRate);
            await this._context.SaveChangesAsync();
        }

        public async Task<ICollection<Review>> GetReviewsAsync(int ebookId)
        {
            var reviewsToEbooks = await this._context.ReviewsToEbooks
                .Where(r => r.EbookId == ebookId)
                .Select(r => r.ReviewId)
                .ToListAsync();
            return await this._context.Reviews
                .Where(r => reviewsToEbooks.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddReviewAsync(int ebookId, string userId, string comment)
        {
            var reviewer = await this._context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (reviewer == null)
                throw new NullReferenceException(nameof(reviewer));
            var review = new Review()
            {
                Reviewer = reviewer,
                Comment = comment
            };
            if (this._context.Reviews.Contains(review))
            {
                this._context.Reviews.Add(review);
                await this._context.SaveChangesAsync();
            }
            var reviewToEbook = new ReviewToEbook()
            {
                Review = await this._context.Reviews.FirstOrDefaultAsync(r => r.Reviewer.Id.Equals(userId) && r.Comment.Equals(comment)),
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId)
            };
            if (!this._context.ReviewsToEbooks.Contains(reviewToEbook))
            {
                this._context.ReviewsToEbooks.Add(reviewToEbook);
                await this._context.SaveChangesAsync();
            }
        }
        public async Task RemoveReviewAsync(int ebookId, string userId, string comment)
        {
            var review = await this._context.Reviews
                .FirstOrDefaultAsync(r => r.Comment.Equals(comment) && r.Reviewer.Id.Equals(userId));
            if (review == null)
                throw new NullReferenceException(nameof(review));
            var reviewToEbook = await this._context.ReviewsToEbooks
                .FirstOrDefaultAsync(r => r.Ebook.ID == ebookId && r.Review.ID == review.ID);
            if (reviewToEbook == null)
                throw new NullReferenceException(nameof(reviewToEbook));
            this._context.ReviewsToEbooks.Remove(reviewToEbook);
            this._context.Reviews.Remove(review);
            await this._context.SaveChangesAsync();
        }

        public async Task<ICollection<Tag>> GetTagsAsync(int ebookId)
        {
            var tagsToEbooks = await this._context.TagsToEbooks
                .Where(t => t.EbookId == ebookId)
                .Select(t => t.TagId)
                .ToListAsync();
            return await this._context.Tags
                .Where(t => tagsToEbooks.Contains(t.ID))
                .ToListAsync();
        }
        public async Task AddTagAsync(int ebookId, string title)
        {
            var tag = new Tag()
            {
                Title = title
            };
            if (!this._context.Tags.Contains(tag))
            {
                this._context.Tags.Add(tag);
                await this._context.SaveChangesAsync();
            }
            var TagToEbook = new TagToEbook()
            {
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId),
                Tag = await this._context.Tags.FirstOrDefaultAsync(t => t.Title.Equals(title))
            };
            if (!this._context.TagsToEbooks.Contains(TagToEbook))
            {
                this._context.TagsToEbooks.Add(TagToEbook);
                await this._context.SaveChangesAsync();
            }
        }
        public async Task RemoveTagAsync(int ebookId, string title)
        {
            var tag = await this._context.Tags.FirstOrDefaultAsync(t => t.Title.Equals(title));
            if (tag == null)
                throw new NullReferenceException(nameof(tag));
            var tagToEbook = await this._context.TagsToEbooks
                .FirstOrDefaultAsync(t => t.EbookId == ebookId && t.Tag.Title.Equals(title));
            if (tagToEbook == null)
                throw new NullReferenceException(nameof(tagToEbook));
            this._context.TagsToEbooks.Remove(tagToEbook);
            this._context.Tags.Remove(tag);
            await this._context.SaveChangesAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
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