using Common.Application;
using Shop.Domain.CategoryAgg.IRepository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand,long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =await _repository.GetTracking(request.parentId, cancellationToken);
            if (category == null)
                return OperationResult<long>.NotFound();
            category.AddChild(request.title,request.slug,request.SeoData,_domainService);
           await _repository.Save();
            return OperationResult<long>.Success(category.Id);


        }
    }
   
}
