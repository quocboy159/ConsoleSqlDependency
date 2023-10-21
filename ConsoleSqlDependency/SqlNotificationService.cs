using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace ConsoleSqlDependency
{
    public class SqlNotificationService : IDisposable
    {
        private SqlTableDependency<Person>? sqlTableDependency;

        public void Start(string connectionString)
        {
            // map data if there are any fields which different name
            //var stockMapper = new ModelToTableMapper<Person>();
            //stockMapper.AddMapping(s => s.FirstName, nameof(Person.FirstName));
            sqlTableDependency = new SqlTableDependency<Person>(connectionString, nameof(Person));
            sqlTableDependency.OnChanged += HandleOnChanged;
            sqlTableDependency.Start();
        }
        public event EventHandler<Person> OnNewMessage;
        public event EventHandler<Person> OnUpdatedMessage;
        public event EventHandler<Person> OnDeleteMessage;

        private void HandleOnChanged(object sender, RecordChangedEventArgs<Person> e)
        {
            switch (e.ChangeType)
            {
                case ChangeType.Delete:
                    OnDeleteMessage?.Invoke(this, e.Entity);
                    break;
                case ChangeType.Insert:
                    OnNewMessage?.Invoke(this, e.Entity);
                    break;
                case ChangeType.Update:
                    OnUpdatedMessage?.Invoke(this, e.Entity);
                    break;
                default:
                    break;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && sqlTableDependency is not null)
                {
                    // invoke Stop() in order to remove all DB objects
                    sqlTableDependency.Stop();
                    sqlTableDependency.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
