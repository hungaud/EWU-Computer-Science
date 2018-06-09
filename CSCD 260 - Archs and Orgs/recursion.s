.data

	prompt1: .asciiz "Number to add for Recursion : \n"
	prompt2: .asciiz "Result: \n"

.text

main:

	#t0 number
	#t1 result

	#prompt intro
	li $v0, 4
	la $a0, prompt1
	syscall
	
	li $v0, 5
	syscall
	addi $s0, $v0, 0
	addi $sp, $sp -4
	sw $s0, 0($sp)
	
	
	
	jal recurse
	#lw $t0, 0($sp)
	#add $v0, $v0, $t0
	#addi $sp, $sp, 4
	
	#la $a0, $v0
	add $a0, $v0, $0
	li $v0, 1
	syscall
	
	
li $v0, 10
syscall	
	
	
recurse:
	lw $t0, 0($sp)
	beq $t0, 0 bailout
	addi $sp, $sp, -8	#set stack space
	addi $t0, $t0, -1
	sw $ra, 4($sp)		# set return register
	sw $t0, 0($sp)		#set number 
	#beq $s0, 0, bailout	#if for base case
	jal recurse
	addi $t2, $t2, 1
	lw $t0, 8($sp)		#load number starting at 1
	add $v0, $v0, $t0	#add to total
	lw $ra, 4($sp)		#load next register	
	addi $sp $sp, 8
	#beq $t2, $s0, final
	jr $ra

	#testing dont look
final:
	lw $t0, 0($sp)
	add $v0, $v0, $t0
	addi $sp, $sp, 4
	jr $ra
	
bailout:
	add $v0, $0, 0		#set sum v0 as 0 to start
	jr $ra






