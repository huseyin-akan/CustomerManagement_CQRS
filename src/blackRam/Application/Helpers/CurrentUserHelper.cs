using Application.Services;
using Core.Application.Services;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class CurrentUserHelper<T>
        where T : AuditableEntity
    {

        public static T HandleCreateCommand(T entityToHandle, ICurrentUserService currentUserService)            
        {
            entityToHandle.CreatedBy = currentUserService.UserId;
            entityToHandle.Created = DateTime.Now;
            entityToHandle.LastModifiedBy = currentUserService.UserId;
            entityToHandle.LastModified = DateTime.Now;

            return entityToHandle;
        }

        public static T HandleUpdateCommand(T entityToHandle, ICurrentUserService currentUserService)
        {
            entityToHandle.LastModifiedBy = currentUserService.UserId;
            entityToHandle.LastModified = DateTime.Now;

            return entityToHandle;
        }
    }
}
