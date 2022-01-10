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
            ebook.UploadDate = DateTime.Today;
            _context.Ebooks.Add(ebook);
        }
        public void Update(Ebook ebook)
        {
           if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var ebookDB = this.Get(ebook.ID);
            ebookDB.RatingsAVG = this.GetRatingsAverage(ebookDB.ID);
            _context.Entry(ebookDB).CurrentValues.SetValues(ebook);
        }
        public async Task UpdateAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var ebookDB = await this.GetAsync(ebook.ID);
            ebookDB.RatingsAVG = await this.GetRatingsAverageAsync(ebookDB.ID);
            _context.Entry(ebookDB).CurrentValues.SetValues(ebook);
        }
        public Ebook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = this._context.Ebooks
                .Include(c => c.Category)
                .Include(e => e.Category)
                .Include(e => e.Creator)
                .FirstOrDefault(e=>e.ID == id);
            ebook.RatingsAVG = this.GetRatingsAverage(ebook.ID);
            return ebook;
        }
        public ICollection<Ebook> GetAll()
        {
            var ebooks = this._context.Ebooks
                .Include(c => c.Creator)
                .Include(c => c.Category)
                .ToList();
            foreach(var ebook in ebooks)
            {
                ebook.RatingsAVG = this.GetRatingsAverage(ebook.ID);
            }
            return ebooks;
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
            var ebooks = await _context.Ebooks
                .Include(c => c.Creator)
                .Include(c => c.Category)
                .ToListAsync();
            foreach(var ebook in ebooks)
            {
                ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            }
            return ebooks;
        }
        public IQueryable<Ebook> GetAllQuerable()
        {
            return this._context.Ebooks;
        }
        public async Task<ICollection<Ebook>> GetAllByCategoryNameAsync(string name, int? packageId)
        {
            var package = await this._context.SubcriptionPackages
                                    .Include(s => s.Videos)
                                    .Include(s => s.Ebooks)
                                    .Include(s => s.Orders)
                                    .FirstOrDefaultAsync(p => p.ID == packageId);

            // Get All Free Videos
            var ebooks = await this._context.Ebooks
                        .Where(e => e.Category.Name.Equals(name) && !e.SubscriptionPackages.Any())
                        .ToListAsync();

            // Get All Packages Videos
            if (package != null)
            {
                foreach (var ebook in package.Ebooks)
                {
                    ebooks.Add(ebook);
                }
            }

            // Get Average Of Ratings
            foreach (var ebook in ebooks.ToList())
            {
                ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            }
            return ebooks.ToList();
        }
        public async Task<ICollection<Ebook>> GetAllByPackageAsync(int? packageId)
        {
            var package = await this._context.SubcriptionPackages
                                    .Include(s => s.Videos)
                                    .Include(s => s.Ebooks)
                                    .Include(s => s.Orders)
                                    .FirstOrDefaultAsync(p => p.ID == packageId);

            // Get All Free Videos
            var ebooks = await this._context.Ebooks
                        .Where(e => !e.SubscriptionPackages.Any())
                        .ToListAsync();

            // Get All Packages Videos
            if (package != null)
            {
                foreach (var ebook in package.Ebooks)
                {
                    ebooks.Add(ebook);
                }
            }

            // Get Average Of Ratings
            foreach (var ebook in ebooks.ToList())
            {
                ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            }
            return ebooks.ToList();
        }
        public ICollection<Ebook> GetAllEmpty()
        {
            var ebooks = this._context.Ebooks.ToList();
            foreach(var ebook in ebooks)
            {
                ebook.RatingsAVG = this.GetRatingsAverage(ebook.ID);
            }
            return ebooks;
        }
        public async Task<ICollection<Ebook>> GetAllEmptyAsync()
        {
            var ebooks = await this._context.Ebooks
                .ToListAsync();
            foreach(var ebook in ebooks)
            {
                ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            }
            return ebooks;
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
            ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            return ebook;

        }
        public Ebook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == id);
            ebook.RatingsAVG = this.GetRatingsAverage(ebook.ID);
            return ebook;
        }
        public async Task<Ebook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            return ebook;

        }
        public IQueryable<Ebook> GetAllQueryable()
        {
            return this._context.Ebooks;
        }
        public async Task<ICollection<Ebook>> GetAllBySearchAsync(string search)
        {
            var ebooks = await this._context.Ebooks
                .Where(e => e.Category.Name.Contains(search) ||
                            e.Content.Contains(search) ||
                            e.Creator.FirstName.Contains(search) ||
                            e.Creator.LastName.Contains(search) ||
                            e.Creator.Email.Contains(search) ||
                            e.Description.Contains(search) ||
                            e.Title.Contains(search))
                            .ToListAsync();
            foreach(var ebook in ebooks)
            {
                ebook.RatingsAVG = await this.GetRatingsAverageAsync(ebook.ID);
            }
            return ebooks;
        }
        public IQueryable<Ebook> GetAllBySearch(IQueryable<Ebook> ebooksQ,string search)
        {
            return ebooksQ
                .Where(e => e.Category.Name.Contains(search) ||
                            e.Content.Contains(search) ||
                            e.Creator.FirstName.Contains(search) ||
                            e.Creator.LastName.Contains(search) ||
                            e.Creator.Email.Contains(search) ||
                            e.Description.Contains(search) ||
                            e.Title.Contains(search));
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
        public float GetRatingsAverage(int? ebookId)
        {
            var ratings = this.GetRetings(ebookId);
            float sum = 0;
            foreach (var rate in ratings)
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
        public ICollection<Rating> GetRetings(int? ebookId)
        {
            var ratingsToEbooks = this._context.RatingsToEbooks
                .Where(r => r.EbookId == ebookId)
                .Select(r => r.RatingId)
                .ToList();
            return this._context.Ratings
                .Where(r => ratingsToEbooks.Contains(r.ID))
                .ToList();
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
            var avg = await this.GetRatingsAverageAsync(ebookId);
            var ebook = await this.GetAsync(ebookId);
            ebook.RatingsAVG = avg;
            this.Update(ebook);
            await this.SaveAsync();
        }
        public void AddRating(int? ebookId, string userId, float rate)
        {
            var rater = this._context.Users.FirstOrDefault(u => u.Id.Equals(userId));
            if (rater == null)
                throw new NullReferenceException(nameof(rater));
            var myRate = new Rating()
            {
                Rate = rate,
                Rater = rater
            };
            this._context.Ratings.Add(myRate);
            this._context.SaveChanges();
            var rateToEbook = new RatingToEbook()
            {
                Rating = this._context.Ratings.FirstOrDefault(r => r.Rate == rate && r.Rater.Id.Equals(rater.Id)),
                Ebook = this._context.Ebooks.FirstOrDefault(e => e.ID == ebookId)
            };
            this._context.RatingsToEbooks.Add(rateToEbook);
            this._context.SaveChanges();
            var avg = this.GetRatingsAverage(ebookId);
            var ebook = this.Get(ebookId);
            ebook.RatingsAVG = avg;
            this.Update(ebook);
            this.Save();
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
            var avg = await this.GetRatingsAverageAsync(ebookId);
            var ebook = await this.GetAsync(ebookId);
            ebook.RatingsAVG = avg;
            this.Update(ebook);
            await this.SaveAsync();
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
                Comment = comment,
                CreatedDate = DateTime.Now
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
            var ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reqToEbookIds = await this._context.RequirementsToEbooks
                                            .Where(r => r.EbookId == ebook.ID)
                                            .Select(r => r.RequirementId)
                                            .ToListAsync();
            return await this._context.Requirements
                        .Where(r => reqToEbookIds.Contains(r.ID))
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
        public async Task RemoveRequirementAsync(int? ebookId, int? requirementId)
        {
            if (ebookId == null)
                throw new ArgumentNullException(nameof(ebookId));
            if (requirementId == null)
                throw new ArgumentNullException(nameof(requirementId));
            var ebook = await this._context.Ebooks.FirstOrDefaultAsync(e => e.ID == ebookId);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reqToEbooks = await this._context.RequirementsToEbooks
                                        .Where(r => r.EbookId == ebook.ID)
                                        .ToListAsync();
            foreach(var req in reqToEbooks)
            {
                if (req.RequirementId == requirementId)
                {
                    this._context.RequirementsToEbooks.Remove(req);
                }
            }
            foreach(var req in await this._context.Requirements.ToListAsync())
            {
                if (req.ID == requirementId)
                {
                    this._context.Requirements.Remove(req);
                }
            }
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