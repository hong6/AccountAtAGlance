using Microsoft.Practices.Unity;
using AccountAtAGlance.Repository;

//use Nuget search Unity
namespace AccountAtAGlance.Model
{
    //for dispose
    public static class ModelContainer
    {
        private static readonly object _Key = new object();
        private static IUnityContainer _Instance;

        //this is private, called internally
        static ModelContainer()
        {
            _Instance = new UnityContainer();
        }

        public static IUnityContainer Instance //when it is called by consumer, get Registered
        {
            get
            {
                _Instance.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
                //_Instance.RegisterType<IAccountRepository, AccountRepository2>(new HierarchicalLifetimeManager()); very flexable, anything like AccountRepository2:IAccountRepository
                _Instance.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());

                return _Instance;
            }
        }
    }


    /*
    //(Singleton) after refactory
    //MVC MORE CLEAN and more loose coupled: changed UnityContainer to IUnityContainer 
    //refer to UnityDependencyResolvers.cs and Global.asax.cs
    public static class ModelContainer
    {
        private static readonly object _Key = new object();
        private static IUnityContainer _Instance;

        //this is private, called internally
        static ModelContainer()
        {
            _Instance = new UnityContainer();
        }

        public static IUnityContainer Instance //when it is called by consumer, get Registered
        {
            get
            {             
                _Instance.RegisterType<IAccountRepository, AccountRepository>();
                //_Instance.RegisterType<IAccountRepository, AccountRepository2>(); very flexable, anything like AccountRepository2:IAccountRepository
                _Instance.RegisterType<ISecurityRepository, SecurityRepository>();
                       
                return _Instance;
            }
        }
    }
    /*

    /*
    //MVC MORE CLEAN and more loose coupled: changed UnityContainer to IUnityContainer 
    //refer to UnityDependencyResolvers.cs and Global.asax.cs
    public static class ModelContainer
    {
        private static readonly object _Key = new object();
        private static IUnityContainer _Instance;

        public static IUnityContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_Key)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new UnityContainer();
                            _Instance.RegisterType<IAccountRepository, AccountRepository>();
                            //_Instance.RegisterType<IAccountRepository, AccountRepository2>(); very flexable, anything like AccountRepository2:IAccountRepository
                            _Instance.RegisterType<ISecurityRepository, SecurityRepository>();
                        }
                    }
                }
                return _Instance;
            }
        }
    }
    */
    


    /* THIS OKAY
    public static class ModelContainer
    {
        private static readonly object _Key = new object();
        private static UnityContainer _Instance;

        public static UnityContainer Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_Key)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new UnityContainer();
                            _Instance.RegisterType<IAccountRepository, AccountRepository>();
                            //_Instance.RegisterType<IAccountRepository, AccountRepository2>(); very flexable, anything like AccountRepository2:IAccountRepository
                            _Instance.RegisterType<ISecurityRepository, SecurityRepository>();
                        }
                    }
                }
                return _Instance;
            }
        }
    }
    */
}
