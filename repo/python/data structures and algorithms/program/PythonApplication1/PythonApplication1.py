#make a class where there is 1 a constructor that makes an empty array 2 a method to pop
# 3 a metod to add 4 a method to check the length 5  a method to check if empety 
from queue import Empty
class Stack:
    def __init__(self):
        self.stack  = [] 
    def isempty(self):
        return len(self.stack) == 0
    def len(self):
       if self.isempty():raise Empty(" stack is empty")
       else:return len(self.stack)
    def top(self): 
        if self.isempty():raise Empty("stack is empty")
        return self.stack(-1)
    def pop(self):
        if self.isempty():
            raise Empty("stack is empty")
        return self.stack.pop()
    def push(self, e):
        self.stack.append(e)
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
    

    