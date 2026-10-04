#make a class where there is 1 a constructor that makes an empty array 2 a method to pop
# 3 a metod to add 4 a method to check the length 5  a method to check if empety
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
        