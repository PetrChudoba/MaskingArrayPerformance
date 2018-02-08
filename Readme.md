# Reddit question - Quickly masking two byte arrays together?
https://www.reddit.com/r/csharp/comments/7w09vc/quickly_masking_two_byte_arrays_together/

So basically, I have two byte arrays:  

    var b1 = new byte[]{123, 12, 1, 21, 321};
    var b2 = new byte[]{0, 0, 333, 0, 0};  

And I want to "merge" these arrays together (quickly being the operative word here) without having to iterate through them and doing a comparison.  Where the "mask" is a 0, nothing will happen, though where it's a non-zero value, the the value will replace the old value.  So I would end up with: 

    result = {123, 12, 333, 21, 321};

Any ideas?


# My results
For:                     544.98618
Parallel.For:            878.3786
Linq:                    4462.49495
Unsafe (arithmetics):    556.6265
Unsafe (increments):     432.628283333333
Vectors:                 187.292024137931
Unsafe vectors:          158.44406875
