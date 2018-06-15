# IDObject工具
### 简介
由于查找物体时，Gameobject.Find比较耗时，路径查找又比较麻烦，因此写了这个可以自动生成一个专属ID的工具，根据ID获得物体。而且在场景运行前就可获取，并存入字典。
### 用法
+ 将ObjectID挂载到物体上，便可自动获取ID，在脚本中调用`ObjectID.GetObjByID(ID)`的方法便可获取物体
+ 在**Tools-IDManager**里有查看、清空字典、查询ID的方法
+ 如果重新加载场景，那么原场景的物体将被销毁，字典需要清空，再运行一下即可
+ __打包时需要清空一下字典，否则会报错__
