using CBProject.HelperClasses;
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
            var videos = this.GetAll()
                .Where(v => v.CreatorId == userId)
                .ToList();
            foreach(var video in videos)
            {
                video.RatingsAVG = this.GetRatingsAverage(video.ID);
            }
            return videos;
        }
        public void Add(Video video)
        {
            if(video == null)
                throw new ArgumentNullException(nameof(video));
            video.Thumbnail = $"{StaticImfo.VideoImagePath}{video.Title}_thambnail.jpg";
            var videoPath = System.Web.HttpContext.Current.Server.MapPath($"~{video.VideoPath}");
            var thumbnailPath = System.Web.HttpContext.Current.Server.MapPath($"~/{video.Thumbnail}");
            VideoEditor.CreateThambnail(videoPath, thumbnailPath, 1);
            video.Duration = VideoEditor.Duration(videoPath);
            video.UploadDate = DateTime.Today;
            this._context.Videos.Add(video);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var video = this.Get(id);
            if (video == null)
                throw new ArgumentNullException(nameof(video));

            var tagsToVideos = this._context.TagsToVideos
                                    .Where(t => t.VideoId == id)
                                    .ToList();
            var ratingsToVideos = this._context.RatingsToVideos
                                    .Where(t => t.VideoId == id)
                                    .ToList();
            var reviewToVideos = this._context.ReviewsToVideos
                                    .Where(r => r.VideoId == id)
                                    .ToList();

            foreach (var tag in tagsToVideos)
            {
                this._context.TagsToVideos.Remove(tag);
            }
            foreach (var rating in ratingsToVideos)
            {
                this._context.RatingsToVideos.Remove(rating);
            }
            foreach (var review in reviewToVideos)
            {
                this._context.ReviewsToVideos.Remove(review);
            }

            var videoPath = System.Web.HttpContext.Current.Server.MapPath($"~{video.VideoPath}");
            var thumbnailPath = System.Web.HttpContext.Current.Server.MapPath($"~/{video.Thumbnail}");
            var imagePath = System.Web.HttpContext.Current.Server.MapPath($"~/{video.VideoImagePath}");
            File.DeleteFile(videoPath);
            File.DeleteFile(thumbnailPath);
            File.DeleteFile(imagePath);
            this._context.Videos.Remove(video);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var video = await this.GetAsync(id);
            if (video == null)
                throw new ArgumentNullException(nameof(video));

            var tagsToVideos = await this._context.TagsToVideos.Where(t => t.VideoId == id).ToListAsync();
            var ratingsToVideos = await this._context.RatingsToVideos.Where(t => t.VideoId == id) .ToListAsync();
            var reviewToVideos = await this._context.ReviewsToVideos.Where(r => r.VideoId == id) .ToListAsync();

            foreach (var tag in tagsToVideos)
            {
                this._context.TagsToVideos.Remove(tag);
            }
            foreach (var rating in ratingsToVideos)
            {
                this._context.RatingsToVideos.Remove(rating);
            }
            foreach (var review in reviewToVideos)
            {
                this._context.ReviewsToVideos.Remove(review);
            }

            var videoPath = System.Web.HttpContext.Current.Server.MapPath($"~{video.VideoPath}");
            var thumbnailPath = System.Web.HttpContext.Current.Server.MapPath($"~/{video.Thumbnail}");
            var imagePath = System.Web.HttpContext.Current.Server.MapPath($"~/{video.VideoImagePath}");
            File.DeleteFile(videoPath);
            File.DeleteFile(thumbnailPath);
            File.DeleteFile(imagePath);
            this._context.Videos.Remove(video);
        }
        public async Task DeleteAllAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            await this.DeleteAsync(id);
        }
        public Video Get(int? id)
        {
            var video =  this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .SingleOrDefault(v => v.ID == id);
            video.RatingsAVG = this.GetRatingsAverage(video.ID);
            return video;
        }
        public ICollection<Video> GetAll()
        {
            var videos = this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .ToList();
            foreach(var video in videos)
            {
                video.RatingsAVG = this.GetRatingsAverage(video.ID);
            }
            return videos;
        }
        public IQueryable<Video> GetAllQuerable()
        {
            return this._context.Videos;
        }
        public ICollection<Video> GetAllEmpty()
        {
            var videos = this._context.Videos.ToList();
            foreach(var video in videos)
            {
                video.RatingsAVG = this.GetRatingsAverage(video.ID);
            }
            return videos;
        }
        public Video GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var video = this._context.Videos.FirstOrDefault(v => v.ID == id);
            video.RatingsAVG = this.GetRatingsAverage(video.ID);
            return video;
        }
        public ICollection<Video> GetOtherVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            var videos = this._context.Videos
                .Where(v => !category.Videos.Contains(v))
                .ToList();
            foreach(var video in videos)
            {
                video.RatingsAVG = this.GetRatingsAverage(video.ID);
            }
            return videos;
        }
        public ICollection<Video> GetVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            var videos = _context.Videos
                .Where(v => category.Videos.Contains(v))
                .ToList();
            foreach( var video in videos)
            {
                video.RatingsAVG = this.GetRatingsAverage(video.ID);
            }
            return videos;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public void Update(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var videoDB = this.Get(video.ID);
            videoDB.RatingsAVG = this.GetRatingsAverage(videoDB.ID);
            _context.Entry(videoDB).CurrentValues.SetValues(video);
        }
        public async Task UpdateAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var videoDB = await this.GetAsync(video.ID);
            videoDB.RatingsAVG = await this.GetRatingsAverageAsync(videoDB.ID);
            _context.Entry(videoDB).CurrentValues.SetValues(video);
        }
        public async Task<Video> GetAsync(int? id)
        {
            var video = await this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .SingleOrDefaultAsync(v => v.ID == id);
            video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            return video;
        }
        public async Task<Video> GetEmptyAsync(int? id)
        {
            var video = await this._context.Videos
                .SingleOrDefaultAsync(v => v.ID == id);
            video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            return video;
        }
        public async Task<ICollection<Video>> GetAllAsync()
        {
            var videos = await this._context.Videos
                .Include(v => v.Category)
                .Include(v => v.Creator)
                .ToListAsync();
            foreach(var video in videos)
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos;
        }
        public async Task<ICollection<Video>> GetAllByCategoryNameAsync(string name, int? packageId)
        {

            var package = await this._context.SubcriptionPackages
                                    .Include(s => s.Videos)
                                    .Include(s => s.Ebooks)
                                    .Include(s => s.Orders)
                                    .FirstOrDefaultAsync(p => p.ID == packageId);

            // Get All Free Videos
            var videos = await this._context.Videos
                .Where(v => v.Category.Name.Equals(name) && !v.SubscriptionPackages.Any())
                .ToListAsync();

            // Get All Packages Videos
            if (package != null)
            {
                foreach (var video in package.Videos)
                {
                    videos.Add(video);
                }
            }

            // Get Average Of Ratings
            foreach (var video in videos.ToList())
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos.ToList(); ;
        }
        public async Task<ICollection<Video>> GetAllByPackageAsync(int? packageId)
        {

            var package = await this._context.SubcriptionPackages
                                    .Include(s => s.Videos)
                                    .Include(s => s.Ebooks)
                                    .Include(s => s.Orders)
                                    .FirstOrDefaultAsync(p => p.ID == packageId);

            // Get All Free Videos
            var videos = await this._context.Videos
                .Where(v => !v.SubscriptionPackages.Any())
                .ToListAsync();

            // Get All Packages Videos
            if (package != null)
            {
                foreach (var video in package.Videos)
                {
                    videos.Add(video);
                }
            }

            // Get Average Of Ratings
            foreach (var video in videos.ToList())
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos.ToList(); ;
        }
        public async Task<ICollection<Video>> GetAllEmptyAsync()
        {
            var videos = await this._context.Videos.ToListAsync();
            foreach(var video in videos)
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos;
        }
        public async Task<ICollection<Video>> GetOtherVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            var videos = await _context.Videos
                .Where(v => !category.Videos.Contains(v))
                .ToListAsync();
            foreach(var video in videos)
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos;
        }
        public async Task<ICollection<Video>> GetVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            var videos = await _context.Videos
                .Where(v => category.Videos.Contains(v))
                .ToListAsync();
            foreach(var video in videos)
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos;
        }
        public IQueryable<Video> GetAllQueryable()
        {
            return this._context.Videos;
        }
        public async Task<ICollection<Video>> GetAllBySearchAsync(string search)
        {
            var videos = await this._context.Videos
                .Where(e => e.Category.Name.Contains(search) ||
                            e.Content.Contains(search) ||
                            e.Creator.FirstName.Contains(search) ||
                            e.Creator.LastName.Contains(search) ||
                            e.Creator.Email.Contains(search) ||
                            e.Description.Contains(search) ||
                            e.Title.Contains(search))
                            .ToListAsync();
            foreach(var video in videos)
            {
                video.RatingsAVG = await this.GetRatingsAverageAsync(video.ID);
            }
            return videos;
        }
        public IQueryable<Video> GetAllBySearch(IQueryable<Video> videosQ, string search)
        {
            return videosQ
                .Where(e => e.Category.Name.Contains(search) ||
                            e.Content.Contains(search) ||
                            e.Creator.FirstName.Contains(search) ||
                            e.Creator.LastName.Contains(search) ||
                            e.Creator.Email.Contains(search) ||
                            e.Description.Contains(search) ||
                            e.Title.Contains(search));
        }

        public async Task<float> GetRatingsAverageAsync(int? videoId)
        {
            var ratings = await this.GetRetingsAsync(videoId);
            float sum = 0;
            foreach (var rate in ratings)
            {
                sum += rate.Rate;
            }
            return sum / ratings.Count;
        }
        public float GetRatingsAverage(int? videoId)
        {
            var ratings = this.GetRetings(videoId);
            float sum = 0;
            foreach (var rate in ratings)
            {
                sum += rate.Rate;
            }
            return sum / ratings.Count;
        }
        public async Task<ICollection<Rating>> GetRetingsAsync(int? videoId)
        {
            var ratingsToVideos = await this._context.RatingsToVideos
                .Where(r => r.VideoId == videoId)
                .Select(r => r.RatingId)
                .ToListAsync();
            return await this._context.Ratings
                .Where(r => ratingsToVideos.Contains(r.ID))
                .ToListAsync();
        }
        public ICollection<Rating> GetRetings(int? videoId)
        {
            var ratingsToVideos = this._context.RatingsToVideos
                .Where(r => r.VideoId == videoId)
                .Select(r => r.RatingId)
                .ToList();
            return this._context.Ratings
                .Where(r => ratingsToVideos.Contains(r.ID))
                .ToList();
        }
        public async Task AddRatingAsync(int? videoId, string userId, float rate)
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
            var avg = await this.GetRatingsAverageAsync(videoId);
            var video = await this.GetAsync(videoId);
            video.RatingsAVG = avg;
            this.Update(video);
            await this.SaveAsync();
        }
        public void AddRating(int? videoId, string userId, float rate)
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
            var rateToVideo = new RatingToVideo()
            {
                Rating = this._context.Ratings.FirstOrDefault(r => r.Rate == rate && r.Rater.Id.Equals(rater.Id)),
                Video = this._context.Videos.FirstOrDefault(e => e.ID == videoId)
            };
            this._context.RatingsToVideos.Add(rateToVideo);
            this._context.SaveChanges();
            var avg = this.GetRatingsAverage(videoId);
            var video = this.Get(videoId);
            video.RatingsAVG = avg;
            this.Update(video);
            this.Save();
        }
        public async Task RemoveRatingAsync(int? videoId, string userId, float rate)
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
            var avg = await this.GetRatingsAverageAsync(videoId);
            var video = await this.GetAsync(videoId);
            video.RatingsAVG = avg;
            this.Update(video);
            await this.SaveAsync();
        }

        public async Task<ICollection<Review>> GetReviewsAsync(int? videoId)
        {
            var reviewsToVideos = await this._context.ReviewsToVideos
                .Where(r => r.VideoId == videoId)
                .Select(r => r.ReviewId)
                .ToListAsync();
            return await this._context.Reviews
                .Where(r => reviewsToVideos.Contains(r.ID))
                .ToListAsync();
        }
        public async Task AddReviewAsync(int? videoId, string userId, string comment)
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
            var reviewToVideo = new ReviewToVideo()
            {
                Review = await this._context.Reviews.FirstOrDefaultAsync(r => r.Reviewer.Id.Equals(userId) && r.Comment.Equals(comment)),
                Video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId)
            };
            this._context.ReviewsToVideos.Add(reviewToVideo);
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveReviewAsync(int? videoId, string userId, string comment)
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

        public async Task<ICollection<Tag>> GetTagsAsync(int? videoId)
        {
            var tagsToVideos = await this._context.TagsToVideos
                .Where(t => t.VideoId == videoId)
                .Select(t => t.TagId)
                .ToListAsync();
            return await this._context.Tags
                .Where(t => tagsToVideos.Contains(t.ID))
                .ToListAsync();
        }
        public async Task AddTagAsync(int? videoId, string title)
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
        public async Task RemoveTagAsync(int? videoId, string title)
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

        public async Task<ICollection<Requirement>> GetRequirementsAsync(int? videoId)
        {
            if (videoId == null)
                throw new ArgumentNullException(nameof(videoId));
            var video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId);
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reqTreq = await this._context.RequirementsToVideos
                                            .Where(r => r.VideoId == video.ID)
                                            .Select(r => r.RequirementId)
                                            .ToListAsync();
            return await this._context.Requirements
                        .Where(r => reqTreq.Contains(r.ID))
                        .ToListAsync();
        }
        public async Task AddRequirementAsync(int? videoId, string content)
        {
            if (videoId == null)
                throw new ArgumentNullException(nameof(videoId));
            this._context.Requirements.Add(
                new Requirement()
                {
                    Content = content
                }
            );
            await this._context.SaveChangesAsync();
            this._context.RequirementsToVideos.Add(
                new RequirementToVideo()
                {
                    Requirement = await this._context.Requirements.FirstOrDefaultAsync(r => r.Content.Equals(content)),
                    Video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId)
                }
            );
            await this._context.SaveChangesAsync();
        }
        public async Task RemoveRequirementAsync(int? videoId, int? requirementId)
        {
            if (videoId == null)
                throw new ArgumentNullException(nameof(videoId));
            if (requirementId == null)
                throw new ArgumentNullException(nameof(requirementId));
            var video = await this._context.Videos.FirstOrDefaultAsync(e => e.ID == videoId);
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reqToVideos = await this._context.RequirementsToVideos
                                        .Where(r => r.VideoId == video.ID)
                                        .ToListAsync();
            foreach (var req in reqToVideos)
            {
                if (req.RequirementId == requirementId)
                {
                    this._context.RequirementsToVideos.Remove(req);
                }
            }
            foreach (var req in await this._context.Requirements.ToListAsync())
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