using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos;
public class BaseAuthDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
