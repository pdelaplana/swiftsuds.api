using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSuds.Domain.Errors;
public record UserAccountNotFound() : DomainError(ErrorCode.UserNotFound, "User Account Not Found");
