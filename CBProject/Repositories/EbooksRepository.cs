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
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await this._context.Ebooks
                                .FirstOrDefaultAsync(e => e.ID == id);
            this._context.Ebooks.Remove(ebook);
        }
        public async Task DeleteAllAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = Get(id);
            if (ebook == null)
                throw new ArgumentNullException(nameof(id));
            var tagsToEbooks = await this._context.TagsToEbooks
                                    .Where(t => t.EbookId == id)
                                    .ToListAsync();
            var ratingsToEbooks = await this._context.RatingsToEbooks
                                    .Where(t => t.EbookId == id)
                                    .ToListAsync();
            var reviewToEbooks = await this._context.ReviewsToEbooks
                                    .Where(r => r.EbookId == id)
                                    .ToListAsync();
            foreach(var tag in tagsToEbooks)
            {
                this._context.TagsToEbooks.Remove(tag);
            }
            foreach (var rating in ratingsToEbooks)
            {
                this._context.RatingsToEbooks.Remove(rating);
            }
            foreach (var review in reviewToEbooks)
            {
                this._context.ReviewsToEbooks.Remove(review);
            }
            _context.Ebooks.Remove(ebook);
        }
        public async Task<ICollection<Ebook>> GetAllAsync()
        {

            return await _context.Ebooks
                .Include(c => c.Category).ToListAsync();
        }
        public IQueryable<Ebook> GetAllQuerable()
        {
            return this._context.Ebooks;
        }
        public async Task<ICollection<Ebook>> GetAllByCategoryNameAsync(string name)
        {
            return await _context.Ebooks
                .Include(e => e.Creator)
                .Include(e => e.Category)
                .Where(e => e.Category.Name.Equals(name))
                .ToListAsync();
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
        public IQueryable<Ebook> GetAllQueryable()
        {
            return this._context.Ebooks;
        }

        public async Task<float> GetRatingsAverageAsync(int? ebookId)
        {
            var ratings = await this.GetRetingsAsync(ebookId);
            float sum = 0;
            foreach(var rate in ratings)
            {
                sum += rate.Rate;
            }
            return sum / ratings.Count;
        }
        public async Task<ICollection<Rating>> GetRetingsAsync(int? ebookId)
        {
            var ratingsToEbooks = await this._context.RatingsToEbooks
                .Where(r => r.EbookId == ebookId)
                .Select(r => r.RatingId)
                .ToListAsync();
            return await this._context.Ratings
                .Where(r => ratingsToEbooks.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddRatingAsync(int? ebookId, string userId, float rate)
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
            var rateToEbook = new RatingToEbook()
            {
                Rating = await this._context.Ratings.FirstOrDefaultAsync(r => r.Rate == rate && r.Rater.Id.Equals(rater.Id)),
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId)
            };
            this._context.RatingsToEbooks.Add(rateToEbook);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveRatingAsync(int? ebookId, string userId, float rate)
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

        public async Task<ICollection<Review>> GetReviewsAsync(int? ebookId)
        {
            var reviewsToEbooks = await this._context.ReviewsToEbooks
                .Where(r => r.EbookId == ebookId)
                .Select(r => r.ReviewId)
                .ToListAsync();
            return await this._context.Reviews
                .Where(r => reviewsToEbooks.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddReviewAsync(int? ebookId, string userId, string comment)
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
            var reviewToEbook = new ReviewToEbook()
            {
                Review = await this._context.Reviews.FirstOrDefaultAsync(r => r.Reviewer.Id.Equals(userId) && r.Comment.Equals(comment)),
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId)
            };
            this._context.ReviewsToEbooks.Add(reviewToEbook);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveReviewAsync(int? ebookId, string userId, string comment)
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

        public async Task<ICollection<Tag>> GetTagsAsync(int? ebookId)
        {
            var tagsToEbooks = await this._context.TagsToEbooks
                .Where(t => t.EbookId == ebookId)
                .Select(t => t.TagId)
                .ToListAsync();
            return await this._context.Tags
                .Where(t => tagsToEbooks.Contains(t.ID))
                .ToListAsync();
        }
        public async Task AddTagAsync(int? ebookId, string title)
        {
            var tag = new Tag()
            {
                Title = title
            };
            this._context.Tags.Add(tag);
            await this._context.SaveChangesAsync();
            var TagToEbook = new TagToEbook()
            {
                Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId),
                Tag = await this._context.Tags.FirstOrDefaultAsync(t => t.Title.Equals(title))
            };
            this._context.TagsToEbooks.Add(TagToEbook);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveTagAsync(int? ebookId, string title)
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

        public async Task<ICollection<Requirement>> GetRequirementsAsync(int? ebookId)
        {
            if (ebookId == null)
                throw new ArgumentNullException(nameof(ebookId));
            var reqTreq = await this._context.RequirementsToEbooks
                                            .Where(r => r.EbookId == ebookId)
                                            .Select(r => r.RequirementId)
                                            .ToListAsync();
            return await this._context.Requirements
                        .Where(r => reqTreq.Contains(r.ID))
                        .ToListAsync();
        }
        public async Task AddRequirementAsync(int? ebookId, string content)
        {
            if (ebookId == null)
                throw new ArgumentNullException(nameof(ebookId));
            this._context.Requirements.Add(
                new Requirement()
                {
                    Content = content
                }
            );
            await this._context.SaveChangesAsync();
            this._context.RequirementsToEbooks.Add(
                new RequirementToEbook()
                {
                    Requirement = await this._context.Requirements.FirstOrDefaultAsync(r => r.Content.Equals(content)),
                    Ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId)
                }
            );
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveRequirementAsync(int? ebookId, string content)
        {
            if (ebookId == null)
                throw new ArgumentNullException(nameof(ebookId));
            var requirement = await this._context.Requirements
                                                .FirstOrDefaultAsync(r => r.Content.Equals(content));
            if (requirement == null)
                throw new ArgumentNullException(nameof(requirement));
            var requirementToEbook = await this._context.RequirementsToEbooks
                                                .FirstOrDefaultAsync(r => r.RequirementId == requirement.ID);
            if (requirementToEbook == null)
                throw new ArgumentNullException(nameof(requirementToEbook));
            this._context.RequirementsToEbooks.Remove(requirementToEbook);
            this._context.Requirements.Remove(requirement);
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