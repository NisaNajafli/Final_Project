﻿using Application.DTOs.DepartmentDto;
using Application.DTOs.TAxDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class TaxController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Tax> taxes = await _unitOfWork.TaxRepository.GetAllAsync();
            List<GetTaxDto> taxDtos = new List<GetTaxDto>();
            foreach (Tax tax in taxes)
            {
                taxDtos.Add(new GetTaxDto()
                {
                    Id = tax.Id,
                    TaxName=tax.TaxName,
                    Percentange=tax.Percentange,
                    Status=tax.Status,

                });
            }
            return Ok(taxDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Tax tax = await _unitOfWork.TaxRepository.GetById(id);
            if (tax == null) return StatusCode(404);
            GetTaxDto taxDtos = new GetTaxDto()
            {
                Id = tax.Id,
                TaxName = tax.TaxName,
                Percentange = tax.Percentange,
                Status = tax.Status,

            };
            return Ok(taxDtos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTax([FromForm] CreateTax taxdto)
        {
            Tax tax = new Tax()
            {
                Status = taxdto.Status,
                Percentange = taxdto.Percentange,
                TaxName = taxdto.TaxName
            };
            _unitOfWork.TaxRepository.Create(tax);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTax([FromRoute] int id)
        {
            Tax tax = await _unitOfWork.TaxRepository.GetById(id);
            if (tax == null) return StatusCode(404);
            _unitOfWork.TaxRepository.Delete(id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateTax([FromRoute] int id, [FromBody] UpdateTAx taxdto)
        {
            Tax tax = await _unitOfWork.TaxRepository.GetById(id);
            if (tax == null) return StatusCode(404);
            tax.TaxName = taxdto.TaxName;
            tax.Status = taxdto.Status;
            tax.Percentange = taxdto.Percentange;
            _unitOfWork.TaxRepository.Update(tax,id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
    }
}
