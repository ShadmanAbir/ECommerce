using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;

namespace ECommerce.Domain.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ECommerceContext _context;


        public UnitOfWork(ECommerceContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*        private GenericRepository<User> userRepository;

                public GenericRepository<User> UserRepository
                {
                    get
                    {

                        if (this.userRepository == null)
                        {
                            this.userRepository = new GenericRepository<User>(_context);
                        }
                        return userRepository;
                    }
                }*/

        private GenericRepository<Product> productRepository;
        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        private GenericRepository<SellPost> sellPostRepository;
        public GenericRepository<SellPost> SellPostRepository
        {
            get
            {

                if (this.sellPostRepository == null)
                {
                    this.sellPostRepository = new GenericRepository<SellPost>(_context);
                }
                return sellPostRepository;
            }
        }

        private GenericRepository<Tag> tagRepository;
        public GenericRepository<Tag> TagRepository
        {
            get
            {

                if (this.tagRepository == null)
                {
                    this.tagRepository = new GenericRepository<Tag>(_context);
                }
                return tagRepository;
            }
        }
        private GenericRepository<Message> messageRepository;
        public GenericRepository<Message> MessageRepository
        {
            get
            {

                if (this.messageRepository == null)
                {
                    this.messageRepository = new GenericRepository<Message>(_context);
                }
                return messageRepository;
            }
        }
        private GenericRepository<SellPostWiseTag> sellPostWiseTagRepository;
        public GenericRepository<SellPostWiseTag> SellPostWiseTagRepository
        {
            get
            {

                if (this.sellPostWiseTagRepository == null)
                {
                    this.sellPostWiseTagRepository = new GenericRepository<SellPostWiseTag>(_context);
                }
                return sellPostWiseTagRepository;
            }
        }
        private GenericRepository<UserBlockList> blockListRepository;
        public GenericRepository<UserBlockList> BlockListRepository
        {
            get
            {

                if (this.blockListRepository == null)
                {
                    this.blockListRepository = new GenericRepository<UserBlockList>(_context);
                }
                return blockListRepository;
            }
        }

        /*        public GenericRepository<User> UserRepository
                {
                    get
                    {

                        if (this.userRepository == null)
                        {
                            this.userRepository = new GenericRepository<User>(_context);
                        }
                        return userRepository;
                    }
                }*/
    }
}
