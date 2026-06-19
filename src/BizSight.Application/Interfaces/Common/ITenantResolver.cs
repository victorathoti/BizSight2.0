public interface ITenantResolver
{
    Guid CompanyId { get; }

    string DatabaseName { get; }

    string ConnectionString { get; }

    int TenantId { get; }
}