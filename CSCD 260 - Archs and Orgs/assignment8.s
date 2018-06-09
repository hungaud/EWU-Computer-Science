.data
	timervalue: .word 0
	newLine: .asciiz "\n"
.text
main:
	mtc0 $0, $9
	addi $t0, $0, 9
	mtc0 $t0, $11
	mfc0 $t0, $12
	ori $t0, $t0, 1
	mtc0 $t0, $12
	
loop:
	la $t0, timervalue
	lw $a0, 0($t0)
	addi $v0, $0, 1
	syscall

	addi $v0, $0, 4
	la $a0, newLine
	syscall	

	j loop

.kdata

.ktext 0x80000180

	la $k0, timervalue
	lw $k1, 0($k0)
	addi $k1, $k1, 1
	sw $k1, 0($k0)

	mtc0 $0, $9
	mtc0 $0, $13
	
	mfc0 $k0, $12
	ori $k0, 0x0001
	mtc0 $k0, $12
	eret