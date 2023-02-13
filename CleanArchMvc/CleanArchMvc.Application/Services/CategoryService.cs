using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    internal class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoryes = await _categoryRepository.GetCategories();

            return _mapper.Map<IEnumerable<CategoryDto>>(categoryes);
        }

        public async Task<CategoryDto> GetById(int? id)
        {
           var category = await _categoryRepository.GetById(id);
           
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(category);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(category);
        }

        public async Task Remove(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            await _categoryRepository.Remove(category);
        }
    }
}
