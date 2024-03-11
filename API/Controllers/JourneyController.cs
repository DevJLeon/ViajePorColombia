using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class JourneyController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    public JourneyController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
}
