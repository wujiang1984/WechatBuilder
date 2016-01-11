/*
Ajax 三级省市联动(兼容JQM)
http://seyea.blogbus.com
Author:张小可(Designer.SK)
日期：2013-8-26

settings 参数说明
-----
url:省市数据josn文件路径
prov:默认省份
city:默认城市
dist:默认地区（县）
nodata:无数据状态(hidden为隐藏,block显示空白)
required:必选项
------------------------------ */
(function($){
	$.fn.citySelect=function(settings){
		if(this.length<1){return;};

		// 默认值
		settings=$.extend({
		    url: "/scripts/city.min.js",
		    prov: null,
		    city: $("#select_city").val(),
		    dist: $("#select_dist").val(),
			nodata:"true",
			required:true
		},settings);

		var box_obj=this;
		var prov_obj = box_obj.find("#select_prov");
		var city_obj = box_obj.find("#select_city");
		var dist_obj = box_obj.find("#select_dist");
		var prov_val = $("#select_prov").val();
		var city_val = $("#select_city").val();
		var dist_val = $("#select_dist").val();
		var select_prehtml=(settings.required) ? "" : "<option value=''>--请选择--</option>";
		var city_json;

		// 赋值市级函数
		var cityStart=function(){
		    var prov_id = $('#select_prov option:selected').index();
			//重选的时候,清空
			city_obj.parent().parent().css("display","block");
			dist_obj.parent().parent().css("display","block");
			$('#select_city').text("");
			$('#select_dist').text("");

			if(!settings.required){
				prov_id--;
			};
			city_obj.empty().attr("disabled",true);
			dist_obj.empty().attr("disabled",true);

			if(prov_id<0||typeof(city_json.citylist[prov_id].c)=="undefined"){
				if(settings.nodata=="hidden"){
					city_obj.parent().parent().css("display","none");
					dist_obj.parent().parent().css("display","none");
				}else if(settings.nodata=="block"){
					city_obj.parent().parent().css("display","block");
					dist_obj.parent().parent().css("display","block");
				};
				return;
			};
			
			// 遍历赋值市级下拉列表
			temp_html=select_prehtml;
			$.each(city_json.citylist[prov_id].c,function(i,city){
				if(i==0){
					//选取的默认值
					
				    $("#select_city").html(city.n);
					temp_html+="<option value='"+city.n+"' selected='selected' >"+city.n+"</option>";
				}else{
				temp_html+="<option value='"+city.n+"'>"+city.n+"</option>";	
				}
				
			});
			city_obj.html(temp_html).attr("disabled",false).css({"display":"","visibility":""});
			
			distStart();
		};

		// 赋值地区（县）函数
		var distStart=function(){
			//重选的时候,清空
			dist_obj.parent().parent().css("display","block");
			$('#select_dist').text("");
			var prov_id=$('.prov option:selected').index();
			var city_id=$('.city option:selected').index();
			if(!settings.required){
				prov_id--;
				city_id--;
			};

			dist_obj.empty().attr("disabled",true);

			if(prov_id<0||city_id<0||typeof(city_json.citylist[prov_id].c[city_id].a)=="undefined"){
				if(settings.nodata=="hidden"){
					dist_obj.parent().parent().css("display","none");
				}else if(settings.nodata=="block"){
					dist_obj.parent().parent().css("display","block");
				};

				return;
			};
			
			// 遍历赋值市级下拉列表
			temp_html=select_prehtml;
			$.each(city_json.citylist[prov_id].c[city_id].a,function(i,dist){
				if(i==0){
				    $("#select_dist").html(dist.s);
					temp_html+="<option value='"+dist.s+"' selected='selected'>"+dist.s+"</option>";

				}else{
					temp_html+="<option value='"+dist.s+"'>"+dist.s+"</option>";
				}
				
			});
			dist_obj.html(temp_html).attr("disabled",false).css({"display":"","visibility":""});
			//页面隐藏
			

		};




		var init=function(){
			// 遍历赋值省份下拉列表
			temp_html=select_prehtml;
			$.each(city_json.citylist,function(i,prov){
					
					if(i==0){
					    $("#select_prov").html(prov.p);
						temp_html+="<option value='"+prov.p+"' selected='selected'>"+prov.p+"</option>";
					}else{
						temp_html+="<option value='"+prov.p+"'>"+prov.p+"</option>";
					}						
			});


			prov_obj.html(temp_html);

			//若有传入省份与市级的值，则选中。（setTimeout为兼容IE6而设置）
			setTimeout(function(){
				if(settings.prov!=null&&settings.prov!=""){
					prov_obj.val(settings.prov);
					$("#select_prov").html(settings.prov);
					cityStart();
					setTimeout(function(){
						if(settings.city!=null){
							city_obj.val(settings.city);
							distStart();
							setTimeout(function(){
								if(settings.dist!=null){
									dist_obj.val(settings.dist);
								};
							},1);
						};
					},1);
				};
			},1);

			// 选择省份时发生事件
			prov_obj.bind("change",function(){
				cityStart();
			});

			// 选择市级时发生事件
			city_obj.bind("change",function(){
				distStart();
			});
			prov_obj.trigger('change');

		};

		// 设置省市json数据
		if(typeof(settings.url)=="string"){
			$.getJSON(settings.url,function(json){
				city_json=json;
				init();
			});
		}else{
			city_json=settings.url;
			init();
		};
	};
})(jQuery);