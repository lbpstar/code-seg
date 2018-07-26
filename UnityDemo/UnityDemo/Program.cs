using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityDemo
{
    public class OperationMain
    {
        IMediaFile _mtype;
        IPlayer _player;

        public OperationMain(IPlayer player, IMediaFile mtype)
        {
            _player = player;
            _mtype = mtype;
        }

        public void PlayMedia()
        {
            _player.Play(_mtype);
        }
    }
    /// <summary>
    /// 播放器
    /// </summary>
    public interface IPlayer
    {
        void Play(IMediaFile file);
    }
    /// <summary>
    /// 默认播放器
    /// </summary>
    public class Player : IPlayer
    {
        public void Play(IMediaFile file)
        {
            Console.WriteLine(file.FilePath);
        }
    }
    /// <summary>
    /// 媒体文件
    /// </summary>
    public interface IMediaFile
    {
        string FilePath { get; set; }
    }
    /// <summary>
    /// 默认媒体文件
    /// </summary>
    public class MediaFile : IMediaFile
    {
        public string FilePath { get; set; }
    }
    class Program
    {
        static UnityContainer container = new UnityContainer();
        static void init()
        {
            container.RegisterType<IPlayer, Player>();
            container.RegisterType<IMediaFile, MediaFile>();
            //疑问：使用container怎样对MediaFile的属性赋值呢
        }
        static void Main(string[] args)
        {
            init();

            OperationMain op1 = container.Resolve<OperationMain>();
            op1.PlayMedia();
            //OperationMain op3 = container.Resolve<OperationMain>();
            //op3.PlayMedia();

            //普通方式
            OperationMain op2 = new OperationMain(new Player(), new MediaFile());
            op2.PlayMedia();

            Console.Read();
        }
    }
}
