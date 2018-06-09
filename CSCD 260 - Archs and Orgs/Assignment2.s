.data

	inputx: .asciiz "\nEnter integer for x: "
	inputy: .asciiz "\nEnter integer for y: "
	menu: .asciiz "ADD: 0	SUB: 1 \n"
	finish: .asciiz "\nEXIT: 9	AGAIN: 0 - 8 \n"
	
.text

main:
	again:

	#print for x
	li $v0, 4
	la $a0, inputx
	syscall
	
	#get x
	li $v0, 5
	syscall
	move $t0, $v0

	#print for y
	li $v0, 4
	la $a0, inputy
	syscall
	
	#get y
	li $v0, 5
	syscall
	move $t1, $v0
	
	#menu
	li $v0, 4
	la $a0, menu
	syscall
	
	#enter menu choice
	li $v0, 5
	syscall
	move $t2, $v0
	
	beq $t2, 0, addition
	beq $t2, 1, subtraction
	
	#add
	addition:
	add $t3, $t0, $t1
	li $v0, 4
	move $a0, $t3
	li $v0, 1
	syscall
	j choice #Jumps to the choice after results
	
	#sub
	subtraction:
	sub $t4, $t0, $t1
	li $v0, 4
	move $a0, $t4
	li $v0, 1
	syscall
	j choice #Jumps to the choice after results
	
	choice:
	#menu
	li $v0, 4
	la $a0, finish
	syscall
	
	#enter menu choice
	li $v0, 5
	syscall
	move $t2, $v0
	
	beq $t2, 9, done
	bne $t2, 9, rerun

	rerun:
	j again # jump to the begining of the program
	
	done:
	li $v0, 10   # syscall 10 = exit    
	syscall	

	




