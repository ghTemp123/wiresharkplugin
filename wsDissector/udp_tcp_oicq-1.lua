-- ����Э�飬������wireshark��ʹ��trivial����
--http://blog.csdn.net/someonea/archive/2008/04/27/2336195.aspx

trivial_proto = Proto("trivial","TRIVIAL","Trivial Protocol")

 

-- dissector����

function trivial_proto.dissector(buffer,pinfo,tree)

   

    --pinfo�ĳ�Ա���Բο��û��ֲ�

    pinfo.cols.protocol = "TRIVIAL"

    pinfo.cols.info = "TRIVIAL data"

   

    local subtree = tree:add(trivial_proto,buffer(),"Trivial Protocol")

          

    --����Ӧ�κ�����

    subtree:add(buffer(0,0),"Message Header: ")

   

    --�汾�Ŷ�Ӧ�ڵ�һ���ֽ�

    subtree:add(buffer(0,1),"Version: " .. buffer(0,1):uint())

   

    --���Ͷ�Ӧ�ڵڶ����ֽ�

    type = buffer(1,1):uint()

    type_str = "Unknown"

    if type == 1 then

        type_str = "REQUEST"

    elseif type == 2 then

        type_str = "RESPONSE"

    end

    subtree:add(buffer(1,1), "Type: " .. type_str)

 

    --�ӵ������ֽڿ�ʼ������

    size = buffer:len()

    subtree:add(buffer(2,size-2), "Data: ")

      

end

 

tcp_table = DissectorTable.get("tcp.port")

--ע�ᵽtcp��8888�˿�

tcp_table:add(14000,trivial_proto)