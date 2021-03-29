
#!/usr/bin/env python
#coding=utf-8

from aliyunsdkcore.client import AcsClient
from aliyunsdkcore.acs_exception.exceptions import ClientException
from aliyunsdkcore.acs_exception.exceptions import ServerException
from aliyunsdkfacebody.request.v20191230.SearchFaceRequest import SearchFaceRequest

client = AcsClient('<accessKeyId>', '<accessSecret>', 'cn-shanghai')

request = SearchFaceRequest()
request.set_accept_format('json')

request.set_ImageUrl("http://viapi-test.oss-cn-shanghai.aliyuncs.com/1.n.png")
request.set_DbName("default")
request.set_Limit(1)

response = client.do_action_with_exception(request)
# python2:  print(response) 
print(str(response, encoding='utf-8'))
