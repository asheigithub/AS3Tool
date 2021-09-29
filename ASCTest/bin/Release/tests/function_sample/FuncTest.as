/*
����ʹ�� FunctionExample��SimpleCollection��EventBroadcaster �� EventListener ����ʾ ActionScript �к����ĸ����÷������������²�����ɵģ� 
FunctionExample �Ĺ��캯������һ����Ϊ simpleColl �ľֲ��������ñ�����һ������������䣬�䷶Χ�� 1 �� 8�� 
ʹ�� trace() ��ӡ simpleColl ����
�� EventListener ���� listener ��ӵ� simpleColl �С�
���� insert() �� remove() ����ʱ����������Ӧ���¼���
�����ڶ��� SimpleCollection ������Ϊ greaterThanFourColl��
���� greaterThanFourColl ���� simpleColl.select() �Ľ�������߰������� 4 ��һ������������SimpleCollection �����ѡ�񷽷���һ���ڲ�����������ʹ����������������Ϊ�顣
*/

package {
	[Doc]
	public class FuncTest{
		public function FuncTest() {
			var simpleColl:SimpleCollection;
            simpleColl = new SimpleCollection(0, 1, 2, 3, 4, 5, 6, 7, 8);
            trace(simpleColl);        // 0, 1, 2, 3, 4, 5, 6, 7, 8

            var listener:EventListener = new EventListener();
            simpleColl.addListener(listener);
            simpleColl.insert(9);        // itemInsertedHandler: 9
            simpleColl.remove(8);        // itemRemovedHandler: 8
            trace(simpleColl);        // 0, 1, 2, 3, 4, 5, 6, 7, 9

            var greaterThanFourColl:SimpleCollection;
            greaterThanFourColl = simpleColl.select(4, function(item:int, value:int){ return item > value });
            trace(greaterThanFourColl);    // 5, 6, 7, 9

			
		}
	}
}
import flash.display.Sprite;
    
class EventBroadcaster {
    private var listeners:Array;

    public function EventBroadcaster() {
        listeners = new Array();
    }
        
    public function addListener(obj:Object):void {
        removeListener(obj);
        listeners.push(obj);
    }
        
    public function removeListener(obj:Object):void {
        for(var i:uint = 0; i < listeners.length; i++) {
            if(listeners[i] == obj) {
                listeners.splice(i, 1);
            }
        }
    }
    
    public function broadcastEvent(evnt:String, ...args):void {
        for(var i:uint = 0; i < listeners.length; i++) {
            listeners[i][evnt].apply(listeners[i], args);
        }
    }    
}
    
class SimpleCollection extends EventBroadcaster {
    private var arr:Array;
        public function SimpleCollection(... args) {
        arr = (args.length == 1 && !isNaN(args[0])) ? new Array(args[0]) : args;
    }
        
    public function insert(obj:Object):void {
        remove(obj);
        arr.push(obj);
        broadcastEvent("itemInsertedHandler", obj);
    }
        
    public function remove(obj:Object):void {
        for(var i:uint = 0; i < arr.length; i++) {
            if(arr[i] == obj) {
                var obj:Object = arr.splice(i, 1)[0];
                broadcastEvent("itemRemovedHandler", obj);
            }
        }
    }

    public function select(val:int, fn:Function):SimpleCollection {
        var col:SimpleCollection = new SimpleCollection();
        for(var i:uint = 0; i < arr.length; i++) {
            if(fn.call(this, arr[i], val)) {
                col.insert(arr[i]);
            }
        }
        return col;
    }
        
    public function toString():String {
        return arr.join();
    }
}

class EventListener {
    public function EventListener() {
    }
    
    public function itemInsertedHandler(obj:Object):void {
        trace("itemInsertedHandler: " + obj);
    }
    
    public function itemRemovedHandler(obj:Object):void {
        trace("itemRemovedHandler: " + obj);        
    }
}

