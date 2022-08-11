using AutoMapper;
using Garage2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage2._0.Services;

public class VehicleTypeService : IVehicleTypeService
{
    private readonly Garage2_0Context _context;

    public VehicleTypeService(Garage2_0Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SelectListItem>> GenerateVehicleTypes(int? selectedId)
        => await _context.VehicleType.Select(vehicleType => new SelectListItem() { Text = vehicleType.Category, Value = vehicleType.Id.ToString(), Selected = vehicleType.Id == selectedId }).ToListAsync();



}
