using Lion.AbpPro.NotificationManagement.Notifications;
using Lion.AbpPro.NotificationManagement.Notifications.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lion.AbpPro.NotificationManagement.EntityFrameworkCore
{
    [ConnectionStringName(NotificationManagementDbProperties.ConnectionStringName)]
    public class NotificationManagementDbContext : AbpDbContext<NotificationManagementDbContext>, INotificationManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public NotificationManagementDbContext(DbContextOptions<NotificationManagementDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Notification> Notifications { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureNotificationManagement();
        }

      
    }
}