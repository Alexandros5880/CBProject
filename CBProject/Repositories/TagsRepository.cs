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
    public class TagsRepository : IRepository<Tag>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public TagsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            this._context.Tags.Add(tag);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var tag = this.Get(id);
            if (tag == null)
                throw new Exception("Tag Not Found");
            this._context.Tags.Remove(tag);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var tag = await this._context.Tags
                                .FirstOrDefaultAsync(t => t.ID == id);
            this._context.Tags.Remove(tag);
        }
        public async Task DeleteAllAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var tag = this.Get(id);
            if (tag == null)
                throw new Exception("Tag Not Found");
            var tagsToEbooks = await this._context.TagsToEbooks
                                .Where(t => t.TagId == id)
                                .ToListAsync();
            var tagsToVideos = await this._context.TagsToVideos
                                .Where(t => t.TagId == id)
                                .ToListAsync();
            foreach(var record in tagsToEbooks)
            {
                this._context.TagsToEbooks.Remove(record);
            }
            foreach(var record in tagsToVideos)
            {
                this._context.TagsToVideos.Remove(record);
            }
            this._context.Tags.Remove(tag);
        }
        public Tag Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Tags
                .SingleOrDefault(t=>t.ID == id);
        }
        public ICollection<Tag> GetAll()
        {
            return this._context.Tags
                .ToList();
        }       
        public ICollection<Tag> GetAllEmpty()
        {
            return this._context.Tags.ToList();
        }      
        public Tag GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Tags
                .FirstOrDefault(t => t.ID == id);
        }        
        public void Save()
        {
            this._context.SaveChanges();
        }       
        public void Update(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            this._context.Entry(tag).State = EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public async Task<Tag> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Tags
                .SingleOrDefaultAsync(t => t.ID == id);
        }
        public async Task<Tag> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Tags
                .SingleOrDefaultAsync(t => t.ID == id);
        }
        public async Task<ICollection<Tag>> GetAllEmptyAsync()
        {
            return await this._context.Tags
                .ToListAsync();
        }
        public async Task<ICollection<Tag>> GetAllAsync()
        {
            return await this._context.Tags
                .ToListAsync();
        }
        public ICollection<Tag> GetAllOtherFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var tagsIds = this._context.TagsToVideos
                        .Where(t => t.VideoId != video.ID)
                        .Select(t => t.TagId)
                        .ToList();
            return this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToList();

        }
        public async Task<ICollection<Tag>> GetAllOtherFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var tagsIds = await this._context.TagsToVideos
                        .Where(t => t.VideoId != video.ID)
                        .Select(t => t.TagId)
                        .ToListAsync();
            return await this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToListAsync();
        }
        public ICollection<Tag> GetAllFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var tagsIds = this._context.TagsToVideos
                        .Where(t => t.VideoId == video.ID)
                        .Select(t => t.TagId)
                        .ToList();
            return this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToList();
        }
        public async Task<ICollection<Tag>> GetAllFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var tagsIds = await this._context.TagsToVideos
                        .Where(t => t.VideoId == video.ID)
                        .Select(t => t.TagId)
                        .ToListAsync();
            return await this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToListAsync();
        }
        public ICollection<Tag> GetAllOtherFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var tagsIds = this._context.TagsToEbooks
                                .Where(t => t.EbookId != ebook.ID)
                                .Select(t => t.TagId)
                                .ToList();
            return this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToList();
        }
        public async Task<ICollection<Tag>> GetAllOtherFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var tagsIds = await this._context.TagsToEbooks
                                .Where(t => t.EbookId != ebook.ID)
                                .Select(t => t.TagId)
                                .ToListAsync();
            return await this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToListAsync();
        }
        public ICollection<Tag> GetAllFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var tagsIds = this._context.TagsToEbooks
                                .Where(t => t.EbookId == ebook.ID)
                                .Select(t => t.TagId)
                                .ToList();
            return this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToList();
        }
        public async Task<ICollection<Tag>> GetAllFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var tagsIds = await this._context.TagsToEbooks
                                .Where(t => t.EbookId == ebook.ID)
                                .Select(t => t.TagId)
                                .ToListAsync();
            return await this._context.Tags
                        .Where(t => tagsIds.Contains(t.ID))
                        .ToListAsync();
        }
        public IQueryable<Tag> GetAllQueryable()
        {
            return this._context.Tags;
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