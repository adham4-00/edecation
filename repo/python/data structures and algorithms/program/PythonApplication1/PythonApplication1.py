from queue import Empty
class Stack:
    def __init__(self):
        self.stack  = []
    def isempty(self):
        return len(self.stack) == 0
    def len(self):
       if self.isempty():
           raise Empty(" stack is empty")
       else:
           return len(self.stack)
    def top(self):
        if self.isempty():
            raise Empty("stack is empty")
        return self.stack(-1)
    def pop(self):
        if self.isempty():
            raise Empty("stack is empty")
        return self.stack.pop()
    def push(self, e):
        self.stack.append(e)
class arrayqueue:
    defualt_capacty = int(10)
    def __init__(self):
        self.queue = [None] * arrayqueue.defualt_capacty
        self.size = 0
        self.f = 0
        return
    def __len__(self):
        return self.size
    def is_empty(self):
        return self.size == 0
    def first(self):
        if self.is_empty():
            raise Empty("queue is rather empty")
        return self.queue[self.f]
    def dequeue(self):
        if self.is_empty():
            raise Empty("queue is rather empty")
        s = self.queue[self.f]
        self.queue[self.f] = None
        self.f = (self.f+ 1)%(len(self.queue))
        self.size = self.size - 1
        return s
    def resize(self, e):
        old = self.queue
        self.queue = [None] * e
        walk = self.f
        for c in range(self.size):
            self.queue[c] = old[walk]
            walk  = (1+walk)% len(old)
        self.f = 0
    def enqueue(self, ee):
        if self.size == len(self.queue):
            self.resize(2*self.size)
        last = (self.f + self.size) % len(self.queue)
        self.queue[last] = ee
        self.size = self.size + 1
class Linked_queue:
    class _node:
        __slots__ = '_element','_next'
        def __init__(self, element , neext):
            self._element = element
            self._next = neext
    def __init__(self):
        self._head = None
        self._tail = None
        self._size = None
    def __len__(self):
        return self._size
    def is_empty(self):
        return self._size == 0
    def first(self):
        if self.is_empty:
            raise Empty("queue is empty")
        return self._head._element
    def enqueu(self, e):
        newset = self._node(e, None)
        if self.is_empty:
            self._head = newset
            self._tail = newset
        else:
            self._tail._next = newset
            self._tail = newset
            self._size +=1
    def dequeue(self):
        if self.is_empty:
            raise Empty("queue is empty")
        answer = self._head._element
        self._head = self._head._next
        self._size -= 1
        if self.is_empty:
            self._tail = None
            self._head = None
        return answer
class linked_stack:
    class _node:
        __slots__ = "_element" , "_next"
        def __init__(self, elment, nexxt):
            self._elements = elment
            self._next = nexxt
    def __init__(self):
        self._head = None
        self._size = 0
    def is_empty(self):
        return self.is_empty == 0
    def __len__(self):
        return self._size
    def top(self):
        if self.is_empty:
            raise Empty("stack is empty")
        return self._head._elements
    def push(self, e):
        self._head = self._node(e , self._head)
        self._size +=1
    def pop(self):
        if self.is_empty:
            raise Empty("stack is empty")
        answer = self._head._elements
        self._head = self._head._next
        self._size -=1
        return answer
class PriorityQueueBase:
    class _item: 
        __slots__ = "_key","_value"
        def __init__(self, k, v): 
            self._key = k 
            self._value = v 
        def __lt__(self, other): 
            return self._key < other._key 
    def is__empty(self): 
        return len(self) == 0 
class heappriorityqueue(PriorityQueueBase):
    def perant(Self,j):
        return (j-1)/2
    def leftchild(Self,j):
        return 2*j +1
    def rightchild(Self,j):
        return 2*j +2
    def has_left(self, j): 
        return self.leftchild(j) < len(self._data)
    def has_right(self, j): 
        return self.rightchild(j) < len(self._data)
    def _swap(self, up , down): 
        placeholder = self._data[up] 
        self._data[up]  = self._data[down]
        self._data[down] = placeholder
    def _upheap(self , j):
        perant = self.perant(j)
        if j > 0 and self._data[j]< self._data[perant]:
                self._swap(j,perant)
                self._upheap(perant)
    def _downheap(self, j): 
        if self.has_left(j) :
            left = self.leftchild(j)
            small_child = left 
            if self.has_right(j):
                right = self.rightchild(j)
                if self._data[right]< self._data[left]:
                    small_child = right
            if self._data[small_child] < self._data[j]:
                self._swap(j,small_child)
                self._downheap
    def __init__(self):
        self._data = []
    def __len__(self): 
        return len (self._data)
    def add(self, key,value):
        self._data.append(self._item(key,value))
        self._upheap(len(self._data)-1)
    def min(self):
        if self.is__empty():
            raise Empty('PriorityQueue is empty')
        item = self._data[0]
        return (item._key, item._value)
    def remove_min(self):
        if self.is__empty():
            raise Empty('PriorityQueue is empty')
        self._swap(0, len(self._data) - 1)
        item = self._data.pop()
        self._downheap(0)
        return (item._key, item._value)
class main:
        newname = ""
        s = Stack()
        print("input the string")
        name = str(input())
        for c in name :
            s.push(c)
        for c in name :
         newname = newname + str(s.pop())
        print(newname)
        newnamee = ""
        ss = arrayqueue()
        print("input the string")
        namee = str(input())
        for c in namee :
            ss.enqueue(c)
        for c in namee :
         newnamee = newnamee + str(ss.dequeue())
        print(newnamee)
