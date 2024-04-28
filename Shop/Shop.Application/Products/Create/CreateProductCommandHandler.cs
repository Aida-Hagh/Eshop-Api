﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.IRepository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create;

internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public CreateProductCommandHandler(IProductDomainService domainService,
        IProductRepository repository, IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

        var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
             request.SubCategoryId, request.SecondarySubCategoryId, _domainService, request.Slug,
             request.SeoData);
         _repository.Add(product);

        var specifacations = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifacations.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.SetSpecification(specifacations);

        await _repository.Save();
        return OperationResult.Success();
    }

}
